using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreCount : MonoBehaviour
{
   

    public int countDownStartValue = 3;
    public TextMeshProUGUI Precount;

    public AudioSource preCountSound;
    public AudioSource startBoomSound;
    public AudioSource musicTheme;


    // Start is called before the first frame update
    void Start()
    {
        


        GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
        Player1.GetComponent<P1Controller>().enabled = false; // player 1 can't give inputs to the playerController

        GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
        Player2.GetComponent<P2Controller>().enabled = false; // player 2 can't give inputs to the playerController

       
        

        countDownTimer();
    }

   public void countDownTimer()
    {
        GameObject countDown = GameObject.Find("Countdown"); // the script finds the Countdown (the one that shows the time left)
        if (countDownStartValue > 0)
        {
            musicTheme.Stop();
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Precount.text = "Round starts in "  + spanTime.Seconds; ;
            preCountSound.Play();
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
            
        }
        else
        {
            PauseMenu.go = true;

            Precount.text = "GO!";
            startBoomSound.Play();
            musicTheme.Play();
           
            countDown.GetComponent<TimerTimeIsUp>().enabled = true; // the script TimerTimeIsUp gets enabled
            countDown.GetComponent<TimerTimeIsUp>().countDownTimer();

            GameObject Player1 = GameObject.Find("Player1"); // the script finds player 1
            Player1.GetComponent<P1Controller>().enabled = true; // player 1 can give inputs to the playerController again
            if (Player1.GetComponent<P1Controller>().rb != null)
            {
                Player1.GetComponent<P1Controller>().rb.isKinematic = false;
            }
            

            GameObject Player2 = GameObject.Find("Player2"); // the script finds player 2
            Player2.GetComponent<P2Controller>().enabled = true; // player 2 can give inputs to the playerController again
            if (Player2.GetComponent<P2Controller>().rb != null)
            {
                Player2.GetComponent<P2Controller>().rb.isKinematic = false;
            }
                


        }
    }
}
