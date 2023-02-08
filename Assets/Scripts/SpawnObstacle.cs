using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    private const int SCALE_FACTOR = 3;

    /// <summary>
    /// Spawns an obstacle at certain predefined positions.
    /// </summary>
    public void Spawn()
    {
        GameObject obs;

        Vector3 spawnScale = new(SCALE_FACTOR, SCALE_FACTOR * 2, SCALE_FACTOR);
        int spawnPoint = (int)PickPosition();

        // 1st Object
        obs = Instantiate(obstaclePrefab, transform);

        obs.transform.localScale = spawnScale;

        if (spawnPoint == (int)Positions.SIDES)
        {
            obs.transform.localPosition = transform.GetChild(0).transform.localPosition;

            // 2nd object
            obs = Instantiate(obstaclePrefab, transform);
            obs.transform.localPosition = transform.GetChild(2).transform.localPosition;
            obs.transform.localScale = spawnScale;
        }
        else {
            Vector3 spawnPosition = transform.GetChild(spawnPoint).transform.localPosition;
            obs.transform.localPosition = spawnPosition;
        }
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
