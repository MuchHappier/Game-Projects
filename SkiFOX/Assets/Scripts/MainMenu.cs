using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    
}
