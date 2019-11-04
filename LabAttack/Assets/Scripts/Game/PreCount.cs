using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreCount : MonoBehaviour
{
    int countDownStartValue = 3;
    public TextMeshProUGUI Precount;

    public AudioSource preCountSound;
    public AudioSource startBoomSound;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<PlayerController>().enabled = false; // player 1 can't give inputs to the playerController

        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<PlayerController>().enabled = false; // player 2 can't give inputs to the playerController

        countDownTimer();
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Precount.text = "Round starts in " + spanTime.Seconds; ;
            preCountSound.Play();
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Precount.text = "GO!";
            startBoomSound.Play();
            GameObject countDown = GameObject.Find("Countdown"); // the script finds the Countdown (the one that shows the time left)
            countDown.GetComponent<TimerTimeIsUp>().enabled = true; // the script TimerTimeIsUp gets enabled

            GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
            Player1.GetComponent<PlayerController>().enabled = true; // player 1 can give inputs to the playerController again

            GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
            Player2.GetComponent<PlayerController>().enabled = true; // player 2 can give inputs to the playerController again
        }
    }
}
