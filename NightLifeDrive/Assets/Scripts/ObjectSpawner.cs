using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    Quaternion rotation = Quaternion.Euler(0, -90, 0);

    // Start is called before the first frame update
    void Start()
    {
        SpwanObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpwanObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject building = Instantiate(objects[index], transform);

        building.transform.localPosition = Vector3.zero;
        building.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
        building.transform.rotation = rotation;
    }
}
