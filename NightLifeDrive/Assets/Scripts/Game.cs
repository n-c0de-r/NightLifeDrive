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
    public static float points;

    // Start is called before the first frame update
    void Start()
    {
        //this.health = health.gameObject.AddComponent<Health>();
        health.setHealth(3);
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.getHealth() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        scoreText.text = points.ToString().Split(",")[0];
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
