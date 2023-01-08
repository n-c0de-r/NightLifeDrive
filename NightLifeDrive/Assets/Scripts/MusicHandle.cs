using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Quelle https://www.youtube.com/watch?v=1Y6suVBaBK8
public class MusicHandle : MonoBehaviour
{
    public static MusicHandle instance;

    // Update is called once per frame
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance==null){
            instance=this;
        }else{
            Destroy(gameObject);
        }
    }
}
