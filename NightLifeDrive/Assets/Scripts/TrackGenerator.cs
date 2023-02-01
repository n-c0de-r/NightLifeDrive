using UnityEngine;

/// <summary>
/// A simple track generator for an endless racer game.
/// Inspired by these videos, but improved the math due
/// to much simpler predefined rectangular track pieces:
/// https://www.youtube.com/watch?v=p1odc--Ephk
/// https://www.youtube.com/watch?v=mHn6kZ6qcM0
/// https://youtube.com/playlist?list=PLvcJYjdXa962PHXFjQ5ugP59Ayia-rxM3
/// https://www.youtube.com/playlist?list=PL0WgRP7BtOez8O7UAQiW0qAp-XfKZXA9W
/// </summary>
public class TrackGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trackTiles;

    [SerializeField] [Range(1, 3)]
    private int obstacleDistance = 1;

    private GameObject nextTile;

    private TileController tileController;

    private Vector3 spawnPosition;

    private int angle = 0;

    private int direction = 0;

    private int obstacleCounter = 11;

    // Start is called before the first frame update
    void Start()
    {
        nextTile = transform.GetChild(0).gameObject;
        tileController = nextTile.GetComponent<TileController>();

        spawnPosition = nextTile.transform.GetChild(0).transform.position;
        nextTile = trackTiles[0];

        while (transform.childCount < 10) SpawnTile();
        obstacleCounter = ResetCounter(obstacleDistance);
    }

    void Update()
    {
        if (obstacleCounter <= 0)
        {
            tileController.SpawnObstacle();
            obstacleCounter = ResetCounter(obstacleDistance);
        }
    }

    /// <summary>
    /// Responsible for generating tiles.
    /// </summary>
    public void GenerateTile()
    {
        // Sets the next tile to generate.
        int chance = Random.Range(0, trackTiles.Length);
        int index = chance % trackTiles.Length;
        nextTile = trackTiles[index];

        direction = 0;

        // 0 = straight line, 1 curve
        if (chance != 0) SetCurve();

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
        obstacleCounter--;
    }
}
