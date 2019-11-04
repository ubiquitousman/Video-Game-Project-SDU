using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public float timeToLerp;
   public float timeLerped = 0.0f;
  Vector3 mainMenuPosition;
  Vector3 teamPosition;
  Vector3 settingsPosition;
  Vector3 soundSettingsPosition;
  Vector3 graphicSettingsPosition;
  Vector3 playSettingsPosition;


    public Vector3 newPosition;
    void Awake()
    {
        newPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        timeLerped += Time.deltaTime;
        
    }


    public void Launch()
    {
        mainMenuPosition = new Vector3(0, 0, -10);
        newPosition = mainMenuPosition;
        timeLerped = 0.0f;
        timeToLerp = 35f;
    }

    public void MainMenu ()
    {
        mainMenuPosition = new Vector3(0, 0, -10);
        newPosition = mainMenuPosition;
        timeLerped = 0.0f;
        timeToLerp = 5f;
    }

    public void Team()
    {
        teamPosition = new Vector3(0, -11, -10);
        newPosition = teamPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void Settings ()
    {
        settingsPosition = new Vector3(-16, 1, -10);
        newPosition = settingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void SoundSettings ()
    {
        soundSettingsPosition = new Vector3(-33, 8, -10);
        newPosition = soundSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void graphicSettings ()
    {
        graphicSettingsPosition = new Vector3(-33, -6, -10);
        newPosition = graphicSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    public void playSettings ()
    {
        playSettingsPosition = new Vector3(20, 1, -10);
        newPosition = playSettingsPosition;
        timeLerped = 0.0f;
        timeToLerp = 10f;
    }

    

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, timeLerped / timeToLerp); // Kameraet flyttes til den nyligt satte lokation
    }

   
}
