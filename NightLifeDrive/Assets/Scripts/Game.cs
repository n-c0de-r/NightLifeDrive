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
        //this.health = health.gameObject.AddComponent<Health>();
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
