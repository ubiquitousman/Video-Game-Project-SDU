using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTimeIsUp : MonoBehaviour
{
    int countDownStartValue = 12;
    public TextMeshProUGUI Countdown;
    string addZero = "";

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            

            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            Countdown.text = "Time Left: " + spanTime.Minutes + ":" + addZero + spanTime.Seconds; ;
            if (spanTime.Seconds<11 && spanTime.Seconds>0)
            {
                addZero = "0";
            }else { addZero = ""; }
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Countdown.text = "Time is up!";
            FindObjectOfType<GameManager>().TimeUp(); // execute void TimeUp() in the GameManager script
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
