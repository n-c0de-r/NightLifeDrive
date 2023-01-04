using UnityEngine;
/// <summary>
/// This class takes care of generating and destroying tiles.
/// </summary>
public class Tile : MonoBehaviour
{
    TrackGenerator trackGenerator;

    // Start is called before the first frame update
    void Start()
    {
        trackGenerator = GameObject.FindObjectOfType<TrackGenerator>();
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
        Destroy(gameObject, 3);
    }
}
