using UnityEngine;

/// <summary>
/// A simple track generator for an endless racer game.
/// </summary>
public class TrackGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject track;

    [SerializeField]
    private GameObject[] trackTiles;

    [SerializeField]
    private GameObject startTile;

    GameObject nextTile;

    private Vector3 spawnPosition;
    [SerializeField]
    private int angle = 0;

    private int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = startTile.transform.GetChild(0).transform.position;
        nextTile = trackTiles[0];

        while (track.transform.childCount < 5) SpawnTile();
    }

    /// <summary>
    /// Just for testing.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetCurve();
            GenerateTile();
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

    private void SpawnTile()
    {
        // Update the rotation according to the latest angle.
        Quaternion rotation = nextTile.transform.rotation * Quaternion.Euler(0, angle, 0);

        // Instantiate a new prefab of the track meta-tile, as child of the parent track with the added angle.
        GameObject temp = Instantiate(nextTile, spawnPosition, rotation, track.transform);

        // Sets the new spawn position to the first (0th) child, an empty game object holding the position.
        spawnPosition = temp.transform.GetChild(0).transform.position;

        // Add the new angle up or down according to direction.
        angle += direction * 90;
    }
}
