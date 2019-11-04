using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public float power = 0.1f;
    public float duration = 5f;
    public Transform camera;
    public float SlowDownAmount = 20f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

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


    }

    void OnTriggerEnter2D(Collider2D other) //if the players touch the collider a function from the GameManager is called
    {
        if (other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().FallP1();
        }

        if (other.tag == "Player2")
        {
            FindObjectOfType<GameManager>().FallP2();
        }

    }



}
