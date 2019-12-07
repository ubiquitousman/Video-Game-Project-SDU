using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController2 : MonoBehaviour
{
    public P2Controller thePlayer; // Reference for spilleren

    private Vector3 startpos;
    private Vector3 lastPlayerPosition; // Den løbende position for spilleren, før teksten bliver flyttet
    private float distanceToMoveX; // Hvor meget skal teksten flyttes af x-aksen
    private float distanceToMoveY; // Hvor meget skal teksten flyttes af y-aksen

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "Player2")
            thePlayer = FindObjectOfType<P2Controller>(); // Vi finder spiller komponenten for at kunne bruge den i vores kode
        lastPlayerPosition = thePlayer.transform.position; // Spillerens position tjekkes ved start
        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMoveX = thePlayer.transform.position.x - lastPlayerPosition.x; // Distancen på x-aksen sættes til differencen mellem spillerens nuværende position (den har lige flyttet sig grundet PlayerController-scriptet) og den sidste position (før spilleren blev flyttet)
        distanceToMoveY = thePlayer.transform.position.y - lastPlayerPosition.y; // Distancen på y-aksen sættes til differencen mellem spillerens nuværende position (den har lige flyttet sig grundet PlayerController-scriptet) og den sidste position (før spilleren blev flyttet)
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distanceToMoveY, transform.position.z); // Teksten flyttes den samme mængde som spilleren er blevet

        lastPlayerPosition = thePlayer.transform.position; // Spillerens nye position tjekkes

    }

    public void StartPosition()
    {
        startpos = this.transform.position;
    }

    public void GoToStartPosition()
    {
        this.transform.position = startpos;
    }
}