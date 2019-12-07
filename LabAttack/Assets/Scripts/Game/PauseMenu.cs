using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool go = false;

    public static bool GameIsPaused = false; // is the game paused?
    public GameObject pauseMenuUI; // We can assign the UI for PauseMenu to this script because this is public
    public GameObject countDown;
    public GameObject preCount;

    public AudioSource pauseSound;
    public AudioSource MenuButtonSound;

    GameManager findGameManager;

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

        if (go == true)
        {
            GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
            Player1.GetComponent<P1Controller>().enabled = true; // player 1 can give inputs to the playerController again

            GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
            Player2.GetComponent<P2Controller>().enabled = true; // player 2 can give inputs to the playerController again
        }

        }

    void Pause ()
    {
        pauseMenuUI.SetActive(true); // enable the UI for PauseMenu
        Time.timeScale = 0f; // things won't move (0 means 0% movementspeed)
        GameIsPaused = true; // the game is now paused

        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<P1Controller>().enabled = false; // player 1 can't give inputs to the playerController

        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<P2Controller>().enabled = false; // player 2 can't give inputs to the playerController

        pauseSound.Play();
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
                               //   SceneManager.LoadScene("VersusLevel"); // load the VersusLevel scene

        //Player 1
        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<P1Controller>().GoToStartPosition();
        Player1.GetComponent<P1Controller>().enabled = false; // player 1 can't give inputs to the playerController
        Player1.GetComponent<P1Controller>().rb.isKinematic = true;
        Player1.GetComponent<P1Controller>().P1Ammo();

        // Player 2
        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<P2Controller>().GoToStartPosition();
        Player2.GetComponent<P2Controller>().enabled = false; // player 2 can't give inputs to the playerController
        Player2.GetComponent<P2Controller>().rb.isKinematic = true;
        Player2.GetComponent<P2Controller>().P2Ammo();
        // Timer
        countDown.GetComponent<TimerTimeIsUp>().CancelInvoke();
        countDown.GetComponent<TimerTimeIsUp>().enabled = false; // the script TimerTimeIsUp gets disabled
        countDown.GetComponent<TimerTimeIsUp>().countDownStartValue = 59;
        countDown.GetComponent<TimerTimeIsUp>().Countdown.text = "Time Left: 1:00";

        //Precount
        Debug.Log("Hallooooo!");
        preCount.SetActive(true);
        preCount.GetComponent<PreCount>().CancelInvoke();
        preCount.GetComponent<PreCount>().countDownStartValue = 3;
        preCount.GetComponent<PreCount>().countDownTimer();

        // Camera
        GameObject MainCamera = GameObject.Find("Main Camera"); // the script finds the Camera
        if (MainCamera.GetComponent<MultipleTargetCamera>().startPosition != null)
        {
            MainCamera.GetComponent<MultipleTargetCamera>().transform.position = MainCamera.GetComponent<MultipleTargetCamera>().startPosition;
        }
       
        MainCamera.GetComponent<MultipleTargetCamera>().enabled = false;

        // Portal
        GameObject Portal = GameObject.Find("Portal"); // the script finds the Portal
        Portal.GetComponent<Portal>().fullyCharged = false;

        // GameManager
        findGameManager = FindObjectOfType<GameManager>();
        findGameManager.PointGiven = false;
        findGameManager.explosion.SetActive(false);



    }


    public void buttonSound()
    {
        MenuButtonSound.Play();
    }


}
