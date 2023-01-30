using UnityEngine;

/// <summary>
/// This class takes care of generating and destroying tiles.
/// </summary>
public class TileController : MonoBehaviour
{
    private const float SPAWN_POINT = 2.5f;
    private const int DELETE_TIME = 60;
    private const int SCALE_FACTOR = 3;

    /// <summary>
    /// Spawns an obstacle at certain predefined positions.
    /// </summary>
    /// <param name="obstacle">The Object to spawn.</param>
    public void SpawnObstacle(GameObject obstacle)
    {
        GameObject obs;

        Transform midTile = transform.GetChild(transform.childCount - 1);
        Vector3 spawnScale = new(SCALE_FACTOR, SCALE_FACTOR * 2, SCALE_FACTOR);
        int xOffset = (int)PickPosition();

        obs = Instantiate(obstacle, midTile);
        obs.transform.localPosition = new Vector3(-SPAWN_POINT + (SPAWN_POINT * xOffset), 0, 0);
        obs.transform.localScale = spawnScale;

        if (xOffset == (int)Positions.SIDES)
        {
            obs.transform.localPosition = new Vector3(-SPAWN_POINT, 0, 0);

            obs = Instantiate(obstacle, midTile);
            obs.transform.localPosition = new Vector3(SPAWN_POINT, 0, 0);
            obs.transform.localScale = spawnScale;
        }
    }

    /// <summary>
    /// Generates a new tile, when a tile is entered.
    /// </summary>
    /// <param name="other"></param>
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
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Body"))
            Destroy(gameObject, DELETE_TIME);
    }

    /// <summary>
    /// Picks a position to spawn objects at.
    /// 0 - on the left.
    /// 1 - in the middle.
    /// 2 - on the right.
    /// 3 - left and right.
    /// </summary>
    /// <returns>Position value enum.</returns>
    private Positions PickPosition()
    {
        int chance = Random.Range(0, 10);
        return (Positions)(chance / 3);
    }

    /// <summary>
    /// Enumeration of positions for obstacles.
    /// </summary>
    public enum Positions
    {
        LEFT, MIDDLE, RIGHT, SIDES
    }
}
