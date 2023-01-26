using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public static Health health = new Health();

    [SerializeField] private AudioSource endSoundEffect;
    
    [SerializeField]
    private TMP_InputField inputName;

    [SerializeField]
    private TextMeshPro namePlate;

    // Start is called before the first frame update
    void Start()
    {   
        //this.health = health.gameObject.AddComponent<Health>();
        health.setHealth(3);

        inputName.text = namePlate.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.getHealth()==0){
            StartCoroutine(End());
        }

        namePlate.text = inputName.text;
    }

    private IEnumerator End(){
        // yield return new WaitForSeconds(endSoundEffect.time*2);
        LooseLife.blinkRoutine=null;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
