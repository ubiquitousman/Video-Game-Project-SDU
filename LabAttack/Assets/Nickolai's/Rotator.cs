using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;



    // Update is called once per frame
    void Update()
    {
        //trasformere det gælde object til at rotere via de 3 axer og gange det med time.deltaTime for at den skal gøre det i bløde overgange pr frame
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * speed);
        
    }
}
