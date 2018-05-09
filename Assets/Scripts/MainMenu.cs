using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Load scence by levels
    // Level 1: Main Menu 
    // Level 2: Game Play
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Closes the game 
    public void QuitGame()
    {
        Application.Quit();      
    }
}
