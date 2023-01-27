using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public static Health health = new Health();

    [SerializeField] private AudioSource endSoundEffect;
    
    [SerializeField]
    private TMP_InputField inputName;

    [SerializeField]
    private TextMeshPro namePlate;


    private float points;
    private float counterMultiplier;
    private float minMultiplier = 0.1f;
    private float maxMultiplier = 10.0f;
    private int modMultiplier = 100;

    // Start is called before the first frame update
    void Start()
    {
        //this.health = health.gameObject.AddComponent<Health>();
        health.setHealth(3);

        inputName.text = namePlate.text;
        points = 0;
        counterMultiplier = minMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.getHealth() == 0)
        {
            StartCoroutine(End());
        }

        namePlate.text = inputName.text;

        if (Input.GetKey(KeyCode.W))
        {
            counterMultiplier = Mathf.Clamp(counterMultiplier + Time.deltaTime, minMultiplier, maxMultiplier);
        }
        else
        {
            counterMultiplier = Mathf.Clamp(counterMultiplier - Time.deltaTime*10, minMultiplier, maxMultiplier);
        }

        points += counterMultiplier * Time.deltaTime;

        if (points >= modMultiplier)
        {
            minMultiplier = Mathf.Clamp(minMultiplier * 2, minMultiplier, maxMultiplier);
            modMultiplier *= 10;
        }

        if (health.getHealth() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        scoreText.text = points.ToString().Split(",")[0];
    }

    private IEnumerator End(){
        // yield return new WaitForSeconds(endSoundEffect.time*2);
        LooseLife.blinkRoutine=null;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
// public class Health 
// {
//      private int health;

//      public int getHealth()
//      {
//           return health;
//      }

//      public void setHealth(int newHealth)
//      {
//           health = newHealth;
//      }

// }
