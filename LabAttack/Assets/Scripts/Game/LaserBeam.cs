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
        if(other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }

        if (other.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }

       

        if (other.tag == "Health" || other.tag == "Ammo" || other.tag == "HealthSpawner" || other.tag == "AmmoSpawner" || other.tag == "RandomSpawner" || other.tag == "Monster")
        {
            // don't destroy
        }
        else
        {
            Instantiate(laserBeamEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
