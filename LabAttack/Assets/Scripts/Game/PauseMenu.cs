using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false; // is the game paused?
    public GameObject pauseMenuUI; // We can assign the UI for PauseMenu to this script because this is public


    void Start()
    {
        GameIsPaused = false; // the game is not paused in the beginning of the game
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if we press the "Escape" key
        {
            if (GameIsPaused) // if the games is paused
            {
                Resume(); // resume the game --> execute the void Resume() 
            } else  // if the game is not paused
            {
                Pause(); // put the game on pause --> execute the void Pause() 
            }
        }
    }


    public void Resume ()
    {
        pauseMenuUI.SetActive(false); // disable the UI for PauseMenu
        Time.timeScale = 1f; // things moves in normal speed (1 means 100 % movementspeed)
        GameIsPaused = false; // the game is not paused now

        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<PlayerController>().enabled = true; // player 1 can give inputs to the playerController again

        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<PlayerController>().enabled = true; // player 2 can give inputs to the playerController again
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true); // enable the UI for PauseMenu
        Time.timeScale = 0f; // things won't move (0 means 0% movementspeed)
        GameIsPaused = true; // the game is now paused

        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<PlayerController>().enabled = false; // player 1 can't give inputs to the playerController

        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<PlayerController>().enabled = false; // player 2 can't give inputs to the playerController
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // things moves in normal speed (1 means 100 % movementspeed)
        SceneManager.LoadScene("MainMenu"); // load the MainMenu scene
      
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game"); // show this in console
        Application.Quit(); // quit the game
    }

    public void GoToSettings()
    {

    }

    public void RestartGame()
    {
        pauseMenuUI.SetActive(false); // disable the UI for PauseMenu
        Time.timeScale = 1f; // things moves in normal speed (1 means 100 % movementspeed)
        GameIsPaused = false;  // the game is not paused now
        SceneManager.LoadScene("VersusLevel"); // load the VersusLevel scene
        
    }

}
