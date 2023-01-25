using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Health health = new Health();
    [SerializeField] private AudioSource endSoundEffect;
    // Start is called before the first frame update
    void Start()
    {   
        //this.health = health.gameObject.AddComponent<Health>();
        health.setHealth(3);
    }

    // Update is called once per frame
    void Update()
    {
        if(health.getHealth()==0){
            StartCoroutine(End());  
        }
    }

    private IEnumerator End(){
        // yield return new WaitForSeconds(endSoundEffect.time*2);
        LooseLife.blinkRoutine=null;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
