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

    public GameObject[] p1flasks;
    public GameObject[] p2flasks;

    public AudioSource hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P1Life <= 0)
        {
            player1.SetActive(false); //we want to deactivate the player
            p2Wins.SetActive(true); //the game over screen will show when player 1 has no lives left
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false); //we want to deactivate the player
            p1Wins.SetActive(true); //the game over screen will show when player 2 has no lives left
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
}
