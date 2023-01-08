using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//source for idea:https://www.youtube.com/watch?v=9rZkiEyS66I

public class LooseLife : MonoBehaviour
{//in3d todo und trigger aus nach 1x crash
    [SerializeField] private float duration;
    //0.2 gut*5
    [SerializeField] private int life;//public in movement
    [SerializeField] private Material blinkMaterial;
    // blinking sprite
    private Material material;
    private Material originalMaterial;
    public Coroutine blinkRoutine;

    void OnTriggerEnter(Collider collision){
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "FullBody" && blinkRoutine==null){
            //sprite of Car
            material = collisionGameObject.GetComponent<Material>();
            //save OG Material for later
            originalMaterial = material;
             if (blinkRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(blinkRoutine);
            }
            // Start the Coroutine, and store the reference for it.
            blinkRoutine = StartCoroutine(BlinkRoutine());
        }
    }
     private IEnumerator BlinkRoutine()
        {
            // Swap to the flashMaterial.
            material = blinkMaterial;
            life--;

            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(duration);
            // After the pause, swap back to the original material.
            material = originalMaterial;
            yield return new WaitForSeconds(duration);
            material = blinkMaterial;
            yield return new WaitForSeconds(duration);
            material = originalMaterial;
            yield return new WaitForSeconds(duration);
            material = blinkMaterial;
            yield return new WaitForSeconds(duration);
            material = originalMaterial;

            // Set the routine to null, signaling that it's finished.
            blinkRoutine = null;
        }
}
