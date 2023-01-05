using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicControl : MonoBehaviour
{
    
    [SerializeField] private AudioClip[] audioClipArray;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = audioClipArray[0];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
