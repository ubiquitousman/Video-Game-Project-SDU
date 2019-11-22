using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        

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
