using UnityEngine;

/// <summary>
/// This class takes care of generating and destroying tiles.
/// </summary>
public class TileController : MonoBehaviour
{
    [SerializeField]
    private SpawnObstacle obstacleSpawner;

    private const int DELETE_TIME = 180;

    /// <summary>
    /// Spawns an obstacle at certain predefined positions.
    /// </summary>
    public void SpawnObstacle()
    {
        obstacleSpawner.Spawn();
    }

    /// <summary>
    /// Generates a new tile, when a tile is entered.
    /// </summary>
    /// <param name="other">The Car</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Body"))
        {
            TrackGenerator trackGenerator = transform.parent.gameObject.GetComponent<TrackGenerator>();
            trackGenerator.GenerateTile();
        }
    }

    /// <summary>
    /// Destroys the current tile, after it has been left.
    /// </summary>
    /// <param name="other">The Car</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Body"))
            Destroy(gameObject, DELETE_TIME);
    }
}
