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

    public string SpawnType = "";
    public GameObject spawnHealth;
    public GameObject spawnAmmo;

    
    void Start()
    {
        SpawnType = this.tag;

            

    }

    void Update()
    {


        if (spawning == true)
        {
            Spawn();
        }
    } 



    public void Spawn()
    {
     

        // How long should it take before it spawns?
        if (SpawnType == "HealthSpawner")
        {
            targetTime = midHealthTime;
        }
        else if (SpawnType == "AmmoSpawner")
            {
            
            targetTime = midAmmoTime;
            }else
            {
                targetTime = 15;
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
            else
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


            spawning = false;
            spawnTimer = 0;
            }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (spawning == false)
        {
            findGameManager = FindObjectOfType<GameManager>();


            if (other.tag == "Player1")
            {
     
                if (findGameManager.P1Life != 5 && (SpawnType == "HealthSpawner" || SpawnType == "RandomSpawner"))
                {
                    spawning = true;
                    other.GetComponent<P1Controller>().spawnHealth = false;
                }
                if (other.GetComponent<P1Controller>().spawnAmmo == true && (SpawnType == "AmmoSpawner" || SpawnType == "RandomSpawner"))
                {
                    spawning = true;
                    other.GetComponent<P1Controller>().spawnAmmo = false;
                }
                
            }
            if (other.tag == "Player2")
            {
       
                if (findGameManager.P2Life != 5 && (SpawnType == "HealthSpawner" || SpawnType == "RandomSpawner"))
                {
                    spawning = true;
                    other.GetComponent<P1Controller>().spawnHealth = false;
                }
                if (other.GetComponent<P2Controller>().spawnAmmo == true && (SpawnType == "AmmoSpawner" || SpawnType == "RandomSpawner"))
                {
                    spawning = true;
                    other.GetComponent<P2Controller>().spawnAmmo = false;
                }
                
            }

        }

    }

}
