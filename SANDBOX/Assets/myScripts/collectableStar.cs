using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectableStar : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;
    public AudioSource collectSound;

        void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Player")
        {
            collectSound.Play();
            theScore += 1;
            scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
            Destroy(gameObject);
        }

        }
}
