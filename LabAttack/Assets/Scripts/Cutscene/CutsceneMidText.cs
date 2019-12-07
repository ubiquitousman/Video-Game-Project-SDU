using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneMidText : MonoBehaviour
{
    public GameObject textBox;
    
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Something horrible has happened in the Liature Science Facility. A scientist cloned himself, and now both claim that they’re the real scientist, and only one shall keep its identity. ";
        yield return new WaitForSeconds(9.8f);
        textBox.GetComponent<Text>().text = "They started shooting laser beams towards each other, but one of the beams accidentally hit the self-destruct button. Now there’s only one minute till the entire laboratory explodes.";
        yield return new WaitForSeconds(9.4f);
        textBox.GetComponent<Text>().text = "Only one scientist can survive. Will he kill the other with laser beams and thus escape before the laboratory explodes, or will he escape through the teleportation pod leaving the other scientist behind to die? ";
        yield return new WaitForSeconds(11.3f);
        textBox.GetComponent<Text>().text = "Only time will tell…";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "";

    }
}
