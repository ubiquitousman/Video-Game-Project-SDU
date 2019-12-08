using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    // Score
    public TextMeshProUGUI P1Score;
    public TextMeshProUGUI P2Score;
    public TextMeshProUGUI BigP1Score;
    public TextMeshProUGUI BigP2Score;
    public TextMeshProUGUI whoWon;
    public bool PointGiven = false;
    public float P1ScoreValue = 0;
    public float P2ScoreValue = 0;
    public float delayBeforeLoad = 1.5f;
    public GameObject ScoreScreen;
    public GameObject ScoreScreenText;
    public GameObject P1WonVisual;
    public GameObject P2WonVisual;


    //Explossion
    public GameObject explosion;

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

    public GameObject[] p1hearts;
    public GameObject[] p2hearts;

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
        delayBeforeLoad = 1.5f;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (PointGiven == true)
        {
            delayBeforeLoad = delayBeforeLoad - Time.deltaTime;
            if (delayBeforeLoad < 0)
            {
                ScoreScreen.SetActive(true);
                ScoreScreenText.SetActive(true);
                Time.timeScale = 0f;
            }
        }
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
       
        /*

        if (suddenDeath) // if it's a tie at TimeIsUp
        {
            P1Life = 1;

            P1Hearts(); // execute void P1Hearts()

            P2Life = 1;

            P2Hearts(); // execute void P2Hearts()

            SuddenDeath.SetActive(true); // the screen will show it's Sudden Death

           
            suddenDeath = false; // this variable is set to false, so the sound won't repeat itself

            
        }*/

        if(P1Life <= 0) 
        {
            p2Win();
            // SceneManager.LoadScene("P2Won"); // Player 2 won the game
        }

        
        if (P2Life <= 0) 
        {
            p1Win();
            // SceneManager.LoadScene("P1Won"); // Player 1 won the game
        }
    }

    public void HurtP1()
    {
        shouldShake = true;
        P1Life -= 1;

        P1Hearts(); // execute void P1Hearts()

        hurtSound.Play(); //when player 1 gets hit, the hurt sound effect will play
    }

    public void HurtP2()
    {
        shouldShake = true;
        P2Life -= 1;

        P2Hearts(); // execute void P2Hearts()

        hurtSound.Play(); //when player 2 gets healed, the heal sound effect will play
    }

    public void HealP1()
    {
        
            P1Life += 1;

            P1Hearts(); // execute void P2Hearts()

        healSound.Play(); //when player 2 gets healed, the heal sound effect will play
        
    }

    public void HealP2()
    {
        if (P2Life != 5)
        {
            P2Life += 1;

            P2Hearts(); // execute void P2Hearts()

            healSound.Play(); //when player 2 gets hit, the hurt sound effect will play
        }
    }

    public void FallP1() // player 1 falls sown (see FallTrigger script)
    {
        shouldShake = true;

        fallSound.Play(); //when player 1 falls down, the fallSound will play

        p2Win();
        GameObject MainCamera = GameObject.Find("Main Camera");
        MainCamera.GetComponent<MultipleTargetCamera>().fellDown = true;
        P1Life = 0;
        P1Hearts(); // execute void P1Hearts()

        hurtSound.Play(); //when player 1 falls down, the hurtSound will also play

        GameObject Player1 = GameObject.Find("Player1");
        Player1.GetComponent<P1Controller>().currentAmmo = 0;

    }

    public void FallP2() // player 2 falls sown (see FallTrigger script)
    {
        shouldShake = true;

        fallSound.Play(); //when player 2 falls down, the fallSound will play

        p1Win();
        GameObject MainCamera = GameObject.Find("Main Camera");
        MainCamera.GetComponent<MultipleTargetCamera>().fellDown = true;
        P2Life = 0;
        P2Hearts(); // execute void P2Hearts()

        hurtSound.Play(); //when player 2 falls down, the hurtSound will also play
        
        GameObject Player2 = GameObject.Find("Player2");
        Player2.GetComponent<P2Controller>().currentAmmo = 0;
    }


    public void P1Hearts()
    {
        for (int i = 0; i < p1hearts.Length; i++)
        {
            if (P1Life > i)
            {
                p1hearts[i].SetActive(true);
            }
            else
            {
                p1hearts[i].SetActive(false);
            }
        }
    }

    public void P2Hearts()
    {
        for (int i = 0; i < p2hearts.Length; i++)
        {
            if (P2Life > i)
            {
                p2hearts[i].SetActive(true);
            }
            else
            {
                p2hearts[i].SetActive(false);
            }
        }
    }

    public void p1Win()
    {
        
        if (PointGiven == false)
        {
            P1ScoreValue++;
            P1Score.text = ""+P1ScoreValue;
            BigP1Score.text = P1Score.text;
            PointGiven = true;
            whoWon.text = "Player 1 eliminated Player 2 and managed to escape the laboratory before it exploded!";
            P1WonVisual.SetActive(true);
            
        }

    }
    public void p2Win()
    {
        
        if (PointGiven == false)
        {
            
            P2ScoreValue++;
            P2Score.text = ""+P2ScoreValue;
            BigP2Score.text = P2Score.text;
            PointGiven = true;
            whoWon.text = "Player 2 eliminated Player 1 and managed to escape the laboratory before it exploded!";
            P2WonVisual.SetActive(true);
            
        }

    }

    public void TimeUp()
    {
        delayBeforeLoad = 1.2f;
        Debug.Log("Time");
        explosionSound.Play();
        explosion.SetActive(true);
        Time.timeScale = 0.5f;
        PointGiven = true;
        P1Life = 0;
        P2Life = 0;
        P1Hearts();
        P2Hearts();
        whoWon.text = "Both Scientists died in the explosion!";
        GameObject Player1 = GameObject.Find("Player1");
        Player1.GetComponent<P1Controller>().currentAmmo = 0;
        GameObject Player2 = GameObject.Find("Player2");
        Player2.GetComponent<P2Controller>().currentAmmo = 0;

        /*
        

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


}
