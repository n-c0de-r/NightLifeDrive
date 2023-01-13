using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
public class Health : MonoBehaviour
{
     private int health;

     public int getHealth()
     {
          return health;
     }

     public void setHealth(int newHealth)
     {
          health = newHealth;
     }
    
}
