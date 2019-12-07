using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkipSceneText : MonoBehaviour
{
    public GameObject textBox;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "Press 'SPACE' to skip intro";
        yield return new WaitForSeconds(30f);
        textBox.GetComponent<Text>().text = "";
    }
}
