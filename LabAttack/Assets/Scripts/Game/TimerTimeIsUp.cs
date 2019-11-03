using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTimeIsUp : MonoBehaviour
{
    int countDownStartValue = 119;
    public TextMeshProUGUI Countdown;

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
            Countdown.text = "Time Left: " + spanTime.Minutes + ":" + spanTime.Seconds; ;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            Countdown.text = "Time is up!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
