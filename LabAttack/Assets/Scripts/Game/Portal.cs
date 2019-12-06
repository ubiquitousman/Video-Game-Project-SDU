using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool fullyCharged = false;
    public AudioSource portalSound;
    GameManager findGameManager;

    void Update ()
    {
        findGameManager = FindObjectOfType<GameManager>();

        /*
        if (findGameManager.fullyCharged)
        {
            fullyCharged = true;
        }
        */
    }



    /* In GameManager
      
    // Portal  
    public float chargedValue = 0;
    public float chargedPercent = 0;
    public bool fullyCharged = false;

    void Update()
    {
        // 
        if (chargedPercent == 100)
            {
                fullyCharged = true;
            }
    }
     
     void TeleportP1 ()
      {
            if (P2 is alive)
            // execute win(1) for P1

            if (P2 is dead)
            // execute win(2) for P1 

      }
    
    void TeleportP2 ()
      {
            if (P1 is alive)
            // execute win(1) for P2

            if (P1 is dead)
            // execute win(2) for P2 

      }
      
      
      
      
     * In player scripts:

    // in OnTriggerEnter2D()
     if (other.tag == "Portal")
     {
        findGameManager = FindObjectOfType<GameManager>();
        findGameManager.TeleportP1   /    findGameManager.TeleportP2

        Destroy(other.gameObject);
        portalSound.Play();
     }

     
     
     */

     void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            SceneManager.LoadScene("P1Won");
        }
        if (other.tag == "Player2")
        {
            SceneManager.LoadScene("P2Won");
        }


    }


}
