using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    

    public float laserSpeed; //how fast the beam is going to move

    private Rigidbody2D rb;

    public GameObject laserBeamEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(laserSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other) //if the laserbeam interacts (collides) with anything else, just make it vanish
    {

        //blood
        if (other.gameObject.tag.Equals("Player1"))
        {
            if (FindObjectOfType<GameManager>().P1Life != 0)
            {
                FindObjectOfType<GameManager>().HurtP1();
                Instantiate(laserBeamEffect, transform.position, transform.rotation);
            }
            
            
        }

        if (other.gameObject.tag.Equals("Player2"))
        {
            if (FindObjectOfType<GameManager>().P2Life != 0)
            {
                FindObjectOfType<GameManager>().HurtP2();
                Instantiate(laserBeamEffect, transform.position, transform.rotation);
            }
        }

        if (other.tag == "Health" || other.tag == "Ammo" || other.tag == "HealthSpawner" || other.tag == "AmmoSpawner" || other.tag == "RandomSpawner" || other.tag == "Monster" || other.tag == "Portal" )
        {
          
            // don't destroy

        }
        else if (other.tag == "Player1")
        {
            if (FindObjectOfType<GameManager>().P1Life == 0)
            {

            }
            else
            {
                Destroy(gameObject);

            }
        }

        else if (other.tag == "Player2")
        {
            if (FindObjectOfType<GameManager>().P2Life == 0)
            {

            }
            else
            {
                Destroy(gameObject);

            }
        }

        else {Destroy(gameObject); }    
        
    }
}
