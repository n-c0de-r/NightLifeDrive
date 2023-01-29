using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buildingArray;

    Quaternion startRotation = Quaternion.Euler(0, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
        SpwanObject();
    }

    /// <summary>
    /// Spawns an Building at the origin of the parent object.
    /// </summary>
    private void SpwanObject()
    {
        int index = Random.Range(0, buildingArray.Length);
        GameObject building = Instantiate(buildingArray[index], transform);

        building.transform.localPosition = Vector3.zero;
        building.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
        building.transform.rotation = startRotation * transform.rotation;
    }
}
