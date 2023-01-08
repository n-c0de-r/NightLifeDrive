using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private int health;
    
    [SerializeField] private GameObject[] heartImageArray;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(health);
    }

    public void SetHealth(int currentHealth)
    {
        foreach (var image in heartImageArray)
        {
            image.SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            heartImageArray[i].SetActive(true);
        }
        
    }
}
