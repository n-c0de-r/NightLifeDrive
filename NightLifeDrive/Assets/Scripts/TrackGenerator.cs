using UnityEngine;

/// <summary>
/// A simple track generator for an endless racer game.
/// </summary>
public class TrackGenerator : MonoBehaviour
{
    [SerializeField]
    private TileController tileController;

    [SerializeField]
    private GameObject[] trackTiles;

    [SerializeField]
    private GameObject startTile;

    [SerializeField]
    GameObject obstaclePrefab;

    [SerializeField] [Range(1, 10)]
    private int SPAWN_DISTANCE = 5;

    private GameObject nextTile;

    private Vector3 spawnPosition;

    private int spawnCounter = 0;

    private int angle = 0;

    private int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = ResetCounter(SPAWN_DISTANCE);

        spawnPosition = startTile.transform.GetChild(0).transform.position;
        nextTile = trackTiles[0];

        while (track.transform.childCount < 10) SpawnTile();
    }

    /// <summary>
    /// Just for testing.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GenerateTile();
        }

        if (spawnCounter == 0)
        {
            tileController.SpawnObstacle(obstaclePrefab);
            spawnCounter = ResetCounter(SPAWN_DISTANCE);
        }
    }

    /// <summary>
    /// Responsible for generating tiles.
    /// </summary>
    public void GenerateTile()
    {
        // Sets the next tile to generate.
        int index = Random.Range(0, trackTiles.Length);
        nextTile = trackTiles[index];

        direction = 0;

        // 0 = straight line, 1 curve
        if (index != 0) SetCurve();
        SpawnTile();
    }

    /// <summary>
    /// Resets the spawn counter between the given bound
    /// and two times the bound. Range is variable.
    /// </summary>
    /// <param name="bound">Inner and outer bound value.</param>
    /// <returns>Final random integer</returns>
    private int ResetCounter(int bound)
    {
        return Random.Range(bound, bound * 2);
    }

    /// <summary>
    /// Sets the curve direction and tile rotation.
    /// </summary>
    private void SetCurve()
    {
        // Yields either -1 or +1
        direction = Random.Range(0, 2) * 2 - 1;

        // If the angle would be over 180 (+180 starting value) degrees, flip the direction
        if (Mathf.Abs(angle + direction * 90) >= 180)
        {
            direction *= -1;
        }

        // Flip the tile along the x axis
        nextTile.transform.localScale = new Vector3(2 * direction, 1, 2);
    }

    /// <summary>
    /// Spawns a new Meta tile at the spawn point position (0th child).
    /// </summary>
    private void SpawnTile()
    {
        // Update the rotation according to the latest angle.
        Quaternion rotation = nextTile.transform.rotation * Quaternion.Euler(0, angle, 0);

        // Instantiate a new prefab of the track meta-tile, as child of the parent track with the added angle.
        GameObject temp = Instantiate(nextTile, spawnPosition, rotation, transform);

        // Sets the new spawn position to the first (0th) child, an empty game object holding the position.
        spawnPosition = temp.transform.GetChild(0).transform.position;

        // Update the tile generator to the new tile.
        tileController = temp.GetComponent<TileController>();

        // Add the new angle up or down according to direction.
        angle += direction * 90;

        // Lower the counter, only street tracks may have obstacles
        spawnCounter--;
    }
}
