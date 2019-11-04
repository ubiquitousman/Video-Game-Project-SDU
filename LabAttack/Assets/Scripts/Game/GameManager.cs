using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int P1Life;
    public int P2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject Tie;

    public bool p1won = false;
    public bool p2won = false;
    public bool tie = false;

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
        
        if (tie) // if it's a tie
        {
            player1.SetActive(false); //we want to deactivate the player
            player2.SetActive(false); //we want to deactivate the player

            Tie.SetActive(true); // the game over screen will show it's a tie

            explosionSound.Play();
            tie = false;

        }

        if(P1Life <= 0 && !p1won && !tie) // this makes sure that only one thing happens (player 2 can't win if player 1 already did or a tie has happened)
        {
            player1.SetActive(false); //we want to deactivate the player
            p2Wins.SetActive(true); //the game over screen will show when player 1 has no lives left

            p2won = true; // Player 2 won the game
        }

        if (P2Life <= 0 && !p2won && !tie) // this makes sure that only one thing happens (player 1 can't win if player 2 already did or a tie has happened)
        {
            player2.SetActive(false); //we want to deactivate the player
            p1Wins.SetActive(true); //the game over screen will show when player 2 has no lives left

            p1won = true; // Player 1 won the game
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
        tie = true;
    }
}
