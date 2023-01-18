using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//source for idea:https://www.youtube.com/watch?v=9rZkiEyS66I//source for Transform: https://www.youtube.com/watch?v=fBLpLZFNtVg

public class LooseLife : MonoBehaviour
{//in3d todo und trigger aus nach 1x crash
    [SerializeField] private float durationPerBlink;
    [SerializeField] private float blinkDuration;
    //0.2 gut*5
    // [SerializeField] private int life;//public in movement
    // public Health health;
    [SerializeField] private Material blinkMaterial;
    // blinking sprite
    private Material material;
    private GameObject carM;
    private Material originalMaterial;
    public static Coroutine blinkRoutine;

    //Music
    [SerializeField] private AudioSource endSoundEffect;
    [SerializeField] private AudioSource triggerSoundEffect;

    void OnTriggerEnter(Collider collision){
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Body" && blinkRoutine==null){
            //sprite of Car
            foreach(Transform child in collisionGameObject.transform){
                if(child.name=="FullBody"){
                    carM=child.gameObject;
                    material = carM.GetComponent<Renderer>().material;
                    break;
                }
            }
            //save OG Material for later
            originalMaterial = material;
            //  if (blinkRoutine != null)
            // {
            //     // In this case, we should stop it first.
            //     // Multiple FlashRoutines the same time would cause bugs.
            //     StopCoroutine(blinkRoutine);
            // }
            // Start the Coroutine, and store the reference for it.
            blinkRoutine = StartCoroutine(BlinkRoutine());
        }
        // else{
        //     triggerSoundEffect.Play();
        // }
    }
     private IEnumerator BlinkRoutine()
        {
            // Swap to the flashMaterial.
            if((Game.health.getHealth())==1) {
                endSoundEffect.Play();
            }else{
                triggerSoundEffect.Play();
            }
            carM.GetComponent<Renderer>().material = blinkMaterial;
            Game.health.setHealth(Game.health.getHealth()-1);
            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(durationPerBlink);
            // After the pause, swap back to the original material.
            carM.GetComponent<Renderer>().material = originalMaterial;

            for(int i=0; i<blinkDuration; i++){
                yield return new WaitForSeconds(durationPerBlink);
                carM.GetComponent<Renderer>().material = blinkMaterial;
                yield return new WaitForSeconds(durationPerBlink);
                // After the pause, swap back to the original material.
                carM.GetComponent<Renderer>().material = originalMaterial;
            }

            // Set the routine to null, signaling that it's finished.
            blinkRoutine = null;
        }
}
