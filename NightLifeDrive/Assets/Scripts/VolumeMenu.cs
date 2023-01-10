using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
    public GameObject volumeMenu;
    // Start is called before the first frame update
    void Start()
    {
        volumeMenu.SetActive(false);
    }

    public void Exit(){
        volumeMenu.SetActive(false);
    }
}
