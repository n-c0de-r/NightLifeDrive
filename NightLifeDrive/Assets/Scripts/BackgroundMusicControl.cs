using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private int trackNumber = 0;
    [SerializeField] private AudioClip[] audioClipArray;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayTrack(audioSource, trackNumber));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayTrack(AudioSource audio, int currentTrackNumber) {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = audioClipArray[currentTrackNumber];
        audio.Play();
    }
    
}
