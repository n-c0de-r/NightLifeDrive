using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public void MainMenuFromGameOver(){
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void RestartFromGameOver(){ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
