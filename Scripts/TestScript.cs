using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            print("calling");
            StartCoroutine(LoadYourAsyncScene("High_Interaction_Impulsive"));
        }
    }
    IEnumerator LoadYourAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        // Wait until the asynchronous scene fully loads
        /*while (!asyncLoad.isDone)
        {
            yield return null;
            //yield return new WaitForSeconds(5); 
        }*/
        //yield return SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }
}
