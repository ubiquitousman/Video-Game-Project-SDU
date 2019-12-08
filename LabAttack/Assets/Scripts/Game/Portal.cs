using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public bool fullyCharged = false;
    public bool closed = false;
    public AudioSource portalSound;
    public AudioSource portalOpeningSound;
    bool soundPlayed = false;
    GameManager findGameManager;
    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    

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
      
     
     */

     void OnTriggerStay2D(Collider2D other)
    {
        if (fullyCharged)
        {
            if (other.tag == "Player1" && !closed)
            {
                anim.ResetTrigger("Charging");
                findGameManager.p1Win();
                other.GetComponent<SpriteRenderer>().enabled = false;
                closed = true;
                if (soundPlayed == false)
                {
                    portalSound.Play();
                    portalOpeningSound.Stop();
                    soundPlayed = true;
                }
            }
            if (other.tag == "Player2" && !closed)
            {
                anim.ResetTrigger("Charging");
                findGameManager.p2Win();
                other.GetComponent<SpriteRenderer>().enabled = false;
                closed = true;
                if (soundPlayed == false)
                {
                    portalSound.Play();
                    portalOpeningSound.Stop();
                    soundPlayed = true;
                }
                
            }
        }

    }

    public void OpeningPortal()
    {
        anim.SetTrigger("Charging");
        
    }

    public void SoundChargeUp()
    {
        portalOpeningSound.Play();
    }
    
}
