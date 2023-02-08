using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateVolume : MonoBehaviour
{
    void Awake(){
        if(PlayerPrefs.HasKey("musicVolume")){
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }
}
