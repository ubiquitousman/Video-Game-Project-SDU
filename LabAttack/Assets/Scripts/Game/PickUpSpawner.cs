using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    GameManager findGameManager;

    public float spawnTimer = 0;
    public float targetTime = 15;
    public float midHealthTime = 20;
    public float midAmmoTime = 10;
    public float randomTime = 10;
    public bool spawning = false;
    public bool touchPlayer = false;
    public bool touchPickup = false;

    public string SpawnType = "";
    public GameObject spawnHealth;
    public GameObject spawnAmmo;

    

    
    void Start()
    {
        SpawnType = this.tag;

            

    }

    void Update()
    {
        if (touchPlayer && !touchPickup)
        {
            spawning = true;
        }
        if ( touchPickup)   
        {
            spawning = false;
        }

        if (spawning == true)
        {
            Spawn();
        }
    } 



    public void Spawn()
    {
        touchPlayer = false;
        touchPickup = false;

        // How long should it take before it spawns?
        if (SpawnType == "HealthSpawner")
        {
            targetTime = midHealthTime;
        }
        else if (SpawnType == "AmmoSpawner")
            {
            
            targetTime = midAmmoTime;
            }
        else if (SpawnType == "RandomSpawner")
            {
             targetTime = randomTime; 
                
            }


            // There is still time before spawning
            if (spawnTimer < targetTime)
            {
            
            spawnTimer = spawnTimer + Time.deltaTime; 
            }
            else // When time is up, it spawns!
            {
        
            if (SpawnType == "HealthSpawner")
            {
                Debug.Log("Spawning Health");
                Instantiate(spawnHealth, this.transform.position, Quaternion.identity);

            }
            else if (SpawnType == "AmmoSpawner")
            {
                Debug.Log("Spawning Ammo");
                Instantiate(spawnAmmo, this.transform.position, Quaternion.identity);

            }
            else if (SpawnType == "RandomSpawner")
            {
                int d5 = Random.Range(1, 6);
                if (d5 == 5 || d5 == 6)
                {
                    Instantiate(spawnHealth, this.transform.position, Quaternion.identity);
                }
                if (d5 < 5)
                {
                    Instantiate(spawnAmmo, this.transform.position, Quaternion.identity);
                }
            }

            touchPickup = true;
            spawning = false;
            spawnTimer = 0;
            randomTime = Random.Range(7, 30);

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (spawning == false)
        {
            findGameManager = FindObjectOfType<GameManager>();


            if (other.tag == "Player1")
            {
                touchPlayer = true;
                if  (SpawnType == "HealthSpawner" || SpawnType == "RandomSpawner")
                {
                    if (other.GetComponent<P1Controller>().spawnHealth == true)
                    {
                        spawning = true;
                        touchPickup = false;
                        other.GetComponent<P1Controller>().spawnHealth = false;
                    }
                }
                if (SpawnType == "AmmoSpawner" || SpawnType == "RandomSpawner")
                {
                    if (other.GetComponent<P1Controller>().spawnAmmo == true)
                    {
                        spawning = true;
                        touchPickup = false;
                        other.GetComponent<P1Controller>().spawnAmmo = false;
                    }
                }
   
            }
            if (other.tag == "Player2")
            {
                touchPlayer = true;
                if (SpawnType == "HealthSpawner" || SpawnType == "RandomSpawner")
                {
                    if (other.GetComponent<P2Controller>().spawnHealth == true)
                    {
                        spawning = true;
                        touchPickup = false;
                        other.GetComponent<P2Controller>().spawnHealth = false;
                    }
                }
                if (SpawnType == "AmmoSpawner" || SpawnType == "RandomSpawner")
                {
                    if (other.GetComponent<P2Controller>().spawnAmmo == true)
                    {
                        spawning = true;
                        touchPickup = false;
                        other.GetComponent<P2Controller>().spawnAmmo = false;
                    }
                }

            }

        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player2"|| other.tag == "Player1")
            { touchPlayer = false; }
            
    }
    

}
