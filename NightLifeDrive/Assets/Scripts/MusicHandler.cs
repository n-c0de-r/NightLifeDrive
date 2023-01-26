using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Quelle: https://www.youtube.com/watch?v=yWCHaTwVblk

public class MusicHandler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Awake()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
        }
        Load();
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
