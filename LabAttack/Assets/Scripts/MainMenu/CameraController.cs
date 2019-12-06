using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float startDelay = 0;
  public float timeToLerp = 0.0f;
  public float timeLerped = 0.0f;
  Vector3 mainMenuPosition;
  Vector3 teamPosition;
  Vector3 settingsPosition;
  Vector3 soundSettingsPosition;
  Vector3 graphicSettingsPosition;
  Vector3 playSettingsPosition;
  Vector3 moveHere;

    public AudioSource launchSound;
    public AudioSource buttonSound;


    public Vector3 newPosition;

   

   

    void Start()
    {
        newPosition = new Vector3(0, 19, -10);

        
    }



    // Update is called once per frame
    void Update()
    {
        timeLerped += Time.deltaTime;
        
    }


    public void Launch()
    {
        launchSound.Play();
        mainMenuPosition = new Vector3(0, 0, -10);
        newPosition = mainMenuPosition;
        timeLerped = 0.0f;
        timeToLerp = 35f;
    }

    public void MainMenu ()
    {
        buttonSound.Play();
        mainMenuPosition = new Vector3(0, 0, -10);
        newPosition = mainMenuPosition;
        timeLerped = 0.0f;
        timeToLerp = 5f;
    }

    public void Team()
    {
        buttonSound.Play();
        teamPosition = new Vector3(0, -11, -10);
        newPosition = teamPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void Settings ()
    {
        buttonSound.Play();
        settingsPosition = new Vector3(-16, 1, -10);
        newPosition = settingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void SoundSettings ()
    {
        buttonSound.Play();
        soundSettingsPosition = new Vector3(-33, 8, -10);
        newPosition = soundSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void graphicSettings ()
    {
        buttonSound.Play();
        graphicSettingsPosition = new Vector3(-33, -6, -10);
        newPosition = graphicSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void playSettings ()
    {
        buttonSound.Play();
        playSettingsPosition = new Vector3(20, 1, -10);
        newPosition = playSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    
    
    void FixedUpdate()
    {
       
        // startDelay is 0 before running this code
        if (startDelay < 3) 
        {
            startDelay += 1;
        }
        // We can skip the first update since the startDelay is == 1 which is not >= 2 (we had some trouble if this was executed in the first FixedUpdate)
        if (startDelay >= 2)
        {
        
            moveHere = Vector3.Lerp(transform.position, newPosition, timeLerped / timeToLerp); // Kameraet flyttes til den nyligt satte lokation

            transform.position = moveHere;
        }

    }

   
}
