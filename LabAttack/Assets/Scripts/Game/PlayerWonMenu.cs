using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWonMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // things moves in normal speed (1 means 100 % movementspeed)
        SceneManager.LoadScene("MainMenu"); // load the MainMenu scene

    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // things moves in normal speed (1 means 100 % movementspeed)
        SceneManager.LoadScene("VersusLevel"); // load the VersusLevel scene

    }
}
