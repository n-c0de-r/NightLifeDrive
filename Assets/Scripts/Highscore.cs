using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highscoreText;
    private float highscore=0;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore");
        highscoreText.text = highscore.ToString().Split(",")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
