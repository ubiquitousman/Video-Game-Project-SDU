using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Portal
    public GameObject portal;
    public Vector3 point1;
   

    // Camera related
    public float power = 0.1f;
    public float duration = 5f;
    public Transform camera;
    public float SlowDownAmount = 20f;
    public bool shouldShake = false;
    Vector3 startPosition;
    float initialDuration;


    public GameObject player1;
    public GameObject player2;

    public int P1Life;
    public int P2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject SuddenDeath;

    public bool p1won = false;
    public bool p2won = false;
    public bool suddenDeath = false;

    public GameObject[] p1flasks;
    public GameObject[] p2flasks;

    public AudioSource hurtSound;
    public AudioSource healSound;
    public AudioSource fallSound;
    public AudioSource explosionSound;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            startPosition = camera.localPosition;
            if (duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * SlowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }


        if (suddenDeath) // if it's a tie at TimeIsUp
        {
            P1Life = 1;

            P1Flasks(); // execute void P1Flasks()

            P2Life = 1;

            P2Flasks(); // execute void P2Flasks()

            SuddenDeath.SetActive(true); // the screen will show it's Sudden Death

           
            suddenDeath = false; // this variable is set to false, so the sound won't repeat itself

        }

        if(P1Life <= 0) 
        {
            SceneManager.LoadScene("P2Won"); // Player 2 won the game
        }

        if (P2Life <= 0) 
        {
            SceneManager.LoadScene("P1Won"); // Player 1 won the game
        }
    }

    public void HurtP1()
    {
        shouldShake = true;
        P1Life -= 1;

        P1Flasks(); // execute void P1Flasks()

        hurtSound.Play(); //when player 1 gets hit, the hurt sound effect will play
    }

    public void HurtP2()
    {
        shouldShake = true;
        P2Life -= 1;

        P2Flasks(); // execute void P2Flasks()

        hurtSound.Play(); //when player 2 gets healed, the heal sound effect will play
    }

    public void HealP1()
    {
        
            P1Life += 1;

            P1Flasks(); // execute void P2Flasks()

            healSound.Play(); //when player 2 gets healed, the heal sound effect will play
        
    }

    public void HealP2()
    {
        if (P2Life != 5)
        {
            P2Life += 1;

            P2Flasks(); // execute void P2Flasks()

            healSound.Play(); //when player 2 gets hit, the hurt sound effect will play
        }
    }

    public void FallP1() // player 1 falls sown (see FallTrigger script)
    {
        shouldShake = true;

        fallSound.Play(); //when player 1 falls down, the fallSound will play

        P1Life = 0;

        P1Flasks(); // execute void P1Flasks()

        hurtSound.Play(); //when player 1 falls down, the hurtSound will also play

    }

    public void FallP2() // player 2 falls sown (see FallTrigger script)
    {
        shouldShake = true;

        fallSound.Play(); //when player 2 falls down, the fallSound will play
        
        P2Life = 0;

        P2Flasks(); // execute void P2Flasks()
        
        hurtSound.Play(); //when player 2 falls down, the hurtSound will also play
    }

    public void TimeUp ()
    {
        
        
        
        
        /*
        explosionSound.Play();
        if (P2Life == P1Life)
        {
            suddenDeath = true;
        }

        else if (P1Life > P2Life)
        {
           SceneManager.LoadScene("P1Won");
        }
        else if (P2Life > P1Life)
        {
            SceneManager.LoadScene("P2Won");
        }
    */
    }



    public void P1Flasks ()
    {
        for (int i = 0; i < p1flasks.Length; i++)
        {
            if (P1Life > i)
            {
                p1flasks[i].SetActive(true);
            }
            else
            {
                p1flasks[i].SetActive(false);
            }
        }
    }

    public void P2Flasks()
    {
        for (int i = 0; i < p2flasks.Length; i++)
        {
            if (P2Life > i)
            {
                p2flasks[i].SetActive(true);
            }
            else
            {
                p2flasks[i].SetActive(false);
            }
        }
    }

}
