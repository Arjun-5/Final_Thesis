using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class loadMainMenu : MonoBehaviour
{
    public static bool loadedagain;
    public Text clickTest;
    private bool callSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        loadedagain = false;
        callSceneLoad = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "Right_Hand" || other.gameObject.tag == "Hands") && Ray_From_Controller.sceneLoadComplete == true)
        {
            clickTest.color = new Color(0, 255, 0);
            SceneManager.LoadScene("Scene_Mode", LoadSceneMode.Single);
            Ray_From_Controller.sceneLoadComplete = false;
            loadedagain = true;
        }
    }
    IEnumerator LoadModeScene(string name)
    {
        AsyncOperation asyncLoad_ModeScene = SceneManager.LoadSceneAsync(name,LoadSceneMode.Single);
        asyncLoad_ModeScene.allowSceneActivation = false;

        while (!asyncLoad_ModeScene.isDone)
        {
            if (asyncLoad_ModeScene.progress >= 0.9f)
            {
                asyncLoad_ModeScene.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
