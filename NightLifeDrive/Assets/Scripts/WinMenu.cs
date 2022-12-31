using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Source: https://www.youtube.com/watch?v=9dYDBomQpBQ, https://www.youtube.com/watch?v=TVSLCZWYL_E
public class WinMenu : MonoBehaviour
{
    public void MainMenuFromWin(){
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void RestartFromWin(){ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        // Time.timeScale = 1f;
        // paused = false; 
    }
}
