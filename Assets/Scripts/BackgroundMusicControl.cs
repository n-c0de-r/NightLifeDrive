using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicControl : MonoBehaviour
{
    [SerializeField] private Song[] songArray;

    [SerializeField] private TMP_Text songTitle;
    [SerializeField] private Animator songAnimation;

    [SerializeField] private int displayDelay = 3;

    private AudioSource audioSource; 
    private int songNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShufflePlaylist(songArray);
        PlaySong(songArray[songNumber]);
    }

    void Update()
    {
        if (!audioSource.isPlaying) NextSong();
    }

    /// <summary>
    /// Gets the next song in the list and plays it.
    /// </summary>
    private void NextSong()
    {
        songNumber++;
        songNumber %= songArray.Length;

        PlaySong(songArray[songNumber]);
    }

    /// <summary>
    /// Plays a given song object.
    /// </summary>
    /// <param name="song">The Song to play.</param>
    private void PlaySong(Song song)
    {
        audioSource.clip = song.file;
        songTitle.text = song.name;
        StartCoroutine(animateSong());
        audioSource.Play();
    }

    /// <summary>
    /// In place shuffling using Knuth shuffle algorithm.
    /// Courtesy of Wikipedia :)
    /// </summary>
    /// <param name="songs">Song collection to shuffle.</param>
    private void ShufflePlaylist(Song[] songs)
    {
        int count = songArray.Length;

        while (count > 1)
        {
            int index = Random.Range(0, count);
            Song tmp = songs[index];
            count--;
            songs[index] = songs[count];
            songs[count] = tmp;
        }
    }

    /// <summary>
    /// Shows the currently played title in an info box.
    /// Basically just switches Animation triggers.
    /// </summary>
    /// <returns>A delay time for the display animation.</returns>
    IEnumerator animateSong()
    {
        songAnimation.SetBool("isShowing", true);
        yield return new WaitForSeconds(displayDelay);

        songAnimation.SetBool("isShowing", false);
    }
}
