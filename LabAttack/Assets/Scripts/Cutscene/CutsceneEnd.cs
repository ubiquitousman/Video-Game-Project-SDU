using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JumpToScene());
    }

    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(35f);
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level");
        while (!operation.isDone)
        {
            yield return null; }
        
        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level");
        }
    }

}