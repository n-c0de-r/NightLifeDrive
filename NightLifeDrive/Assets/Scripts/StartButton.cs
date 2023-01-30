using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject volumeMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void VolumeMenu(){
        volumeMenu.SetActive(true);
    }
}
