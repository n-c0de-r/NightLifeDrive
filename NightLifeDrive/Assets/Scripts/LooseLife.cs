using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looseLife : MonoBehaviour
{//in3d todo und trigger aus nach 1x crash
    void OnTriggerEnter2D(Collider2D collision){
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Car"){
            // life--;
        }
    }
}
