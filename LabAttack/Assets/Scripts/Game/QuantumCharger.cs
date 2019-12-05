using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumCharger : MonoBehaviour
{
    public bool charging = false;
    public bool onCooldown = false;
    public float timerValue = 0;
    public float chargeValue = 2;
    

    void Timer()
    {
        // Reset Timer
        // Start Timer
        Debug.Log("Timer has started!");
    }

    public void Charge()
    {
        // add (chargeValue) to total value in the GameManager
        Debug.Log("It is charging!");
    }

    public void Sabotage()
    {
        //Start cooldown timer
        Debug.Log("The charger has been sabotaged!");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!onCooldown)
        {
            if ((other.tag == "Player1" && other.tag != "Player2") || (other.tag == "Player2" && other.tag != "Player1")) // if one is alone on the point
            {

                Timer();

            }

            if (other.tag == "Player1" || other.tag == "Player2") // if at least one is on the point
            {
                if (timerValue > 3)
                {
                    Charge();
                    charging = true;
                }
            }
        
        
        }

    }



    /*
     In Laserbeam script

    public AudioSource sabotageSound;

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Charger")
         {
            // Get Component of other
            // other.charging = false;
            // sabotageSound.Play();
            // other.Sabotage();
         }
    }
     
     */


}
