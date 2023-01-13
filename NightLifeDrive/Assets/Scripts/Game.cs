using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Health health = new Health();
    // Start is called before the first frame update
    void Start()
    {
        health.setHealth(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(health.getHealth()==0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
