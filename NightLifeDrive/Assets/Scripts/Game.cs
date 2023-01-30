using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TMP_InputField inputName;

    [SerializeField]
    private TextMeshPro namePlate;

    public static Health health = new Health();

    private float points;
    private float counterMultiplier;
    private float minMultiplier = 0.1f;
    private float maxMultiplier = 10.0f;
    private int modMultiplier = 100;

    private string defaultName = "U-KNIGHT";

    // Start is called before the first frame update
    void Start()
    {
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

        if (health.getHealth() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (!namePlate.text.Equals(inputName.text))
            namePlate.text = inputName.text;

        if (inputName.text == null || inputName.text.Equals(""))
        {
            inputName.text = defaultName;
            namePlate.text = defaultName;
        }

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

        scoreText.text = points.ToString().Split(",")[0];
    }

    private IEnumerator End(){
        LooseLife.blinkRoutine=null;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

