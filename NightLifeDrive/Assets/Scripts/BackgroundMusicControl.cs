using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicControl : MonoBehaviour
{
    private AudioSource audioSource; 
    public int trackNumber = 0;
    [SerializeField] private AudioClip[] audioClipArray;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //TODO: Shuffle Playlist here (or don't)
        //ShufflePlayList();
        //Idea -> start at a randomized start
        StartCoroutine(loopMusic(audioSource));
    }

    private IEnumerator loopMusic(AudioSource audio) {
        while (true) {
            audio.clip = audioClipArray[trackNumber];
            audio.Play();

            //yield return null;
            yield return new WaitForSeconds(audio.clip.length);

            trackNumber++;

            if (trackNumber >= audioClipArray.Length) {
                trackNumber = 0;
            }
        }
    }

    private int ShufflePlaylist()
    {
        return 0;
    }
    
}
