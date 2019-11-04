using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    public AudioSource fallSound;
    public AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (suddenDeath) // if it's a tie at TimeIsUp
        {
            P1Life = 1;

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

            P2Life = 1;

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
        P1Life -= 1;

        for(int i = 0; i < p1flasks.Length; i++)
        {
            if(P1Life > i)
            {
                p1flasks[i].SetActive(true);
            } else
            {
                p1flasks[i].SetActive(false);
            }
        }
        hurtSound.Play(); //when player 1 gets hit, the hurt sound effect will play
    }

    public void HurtP2()
    {
        P2Life -= 1;

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
        hurtSound.Play(); //when player 2 gets hit, the hurt sound effect will play
    }

    public void FallP1() // player 1 falls sown (see FallTrigger script)
    {
        fallSound.Play(); //when player 1 falls down, the fallSound will play

        P1Life = 0;

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

        hurtSound.Play(); //when player 1 falls down, the hurtSound will also play

    }

    public void FallP2() // player 2 falls sown (see FallTrigger script)
    {
        fallSound.Play(); //when player 2 falls down, the fallSound will play
        
        P2Life = 0;

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
        
        hurtSound.Play(); //when player 2 falls down, the hurtSound will also play
    }

    public void TimeUp ()
    {
        explosionSound.Play();
        if (P2Life == P1Life)
        { suddenDeath = true; }

        else if (P1Life > P2Life)
        { SceneManager.LoadScene("P1Won"); }
        else if (P2Life>P1Life)
        { SceneManager.LoadScene("P2Won"); }
    }
}
