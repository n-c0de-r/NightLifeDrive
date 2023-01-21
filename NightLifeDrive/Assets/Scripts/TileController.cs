using UnityEngine;

/// <summary>
/// This class takes care of generating and destroying tiles.
/// </summary>
public class TileController : MonoBehaviour
{
    [SerializeField]
    TrackGenerator trackGenerator;

    //Transform midTile;

    private const int deleteTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        trackGenerator = transform.parent.gameObject.GetComponent<TrackGenerator>();
    }

    public void SpawnObstacle(GameObject obstacle)
    {
        Transform midTile = transform.GetChild(transform.childCount - 1);

        int xOffset = PickPosition();

        GameObject obs1, obs2;

        obs1 = Instantiate(obstacle, midTile);
        obs1.transform.localPosition = new Vector3(-2.5f * xOffset, 0, 0);
        obs1.transform.localScale = new Vector3(2, 4, 2);

        if (xOffset == 3)
        {
            obs1.transform.localPosition = new Vector3(-2.5f, 0, 0);

            obs2 = Instantiate(obstacle, midTile);
            obs2.transform.localPosition = new Vector3(2.5f, 0, 0);
            obs2.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    /// <summary>
    /// Generates a new tile, when a tile is entered.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        trackGenerator.GenerateTile();
    }

    /// <summary>
    /// Destroys the current tile, after it has been left.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject, deleteTime);
    }

    private int PickPosition()
    {
        int chance = Random.Range(0, 10);

        return chance /= 3;
    }
}
