using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicControl : MonoBehaviour
{
    [SerializeField] private TMP_Text songTitle;
    [SerializeField] private Animator songAnimation;

    [SerializeField] private int displayDelay = 3;

    private AudioSource audioSource; 
    private int trackNumber = 0;
    //[SerializeField] private AudioClip[] audioClipArray;

    [SerializeField] private Song[] songArray;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //TODO: Shuffle Playlist here (or don't)
        ShufflePlaylist(songArray);
        //Idea -> start at a randomized start
        StartCoroutine(loopMusic(audioSource));
    }

    private IEnumerator loopMusic(AudioSource audio) {
        while (true) {
            //audio.clip = audioClipArray[trackNumber];
            audio.clip = songArray[trackNumber].file;
            songTitle.text = songArray[trackNumber].name;
            StartCoroutine(animateSong());
            audio.Play();

            //yield return null;
            yield return new WaitForSeconds(audio.clip.length);

            trackNumber++;

            /*if (trackNumber >= audioClipArray.Length) {
            {
                    trackNumber = 0;
            }*/

            trackNumber %= songArray.Length;
        }
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

    IEnumerator animateSong()
    {
        songAnimation.SetBool("isShowing", true);
        yield return new WaitForSeconds(displayDelay);

        songAnimation.SetBool("isShowing", false);
    }
}
