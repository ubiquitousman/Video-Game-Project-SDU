using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Start()
    {
        GameIsPaused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject Player1 = GameObject.Find("Player1");
        Player1.GetComponent<PlayerController>().enabled = true;

        GameObject Player2 = GameObject.Find("Player2");
        Player2.GetComponent<PlayerController>().enabled = true;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        GameObject Player1 = GameObject.Find("Player1");
        Player1.GetComponent<PlayerController>().enabled = false;

        GameObject Player2 = GameObject.Find("Player2");
        Player2.GetComponent<PlayerController>().enabled = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void GoToSettings()
    {

    }

    public void RestartGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("VersusLevel");
        
    }

}
