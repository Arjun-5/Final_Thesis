using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class TotalButtonPressed : MonoBehaviour
{
    private string filewriteLocation;
    private StreamWriter filewriter;
    private int userId;
    private string currentSceneName;
    private int buttonPressedCount;
    private string fileName;
    // Start is called before the first frame update
    void Start()
    {
        userId = 3;
        filewriteLocation = Application.persistentDataPath + "/Buttons_Pressed_Count/";   
    }

    // Update is called once per frame
    void Update()
    {
        if (playBeep.CanWrite == true || Input.GetKey(KeyCode.V))
        {
            buttonPressedCount = buttonCountTracking.buttonCount;
            currentSceneName = Ray_From_Controller.loadedScene;
            if (!Directory.Exists(filewriteLocation))
            {
                Directory.CreateDirectory(filewriteLocation);
                fileWrite();
            }
            else
                fileWrite();
            playBeep.CanWrite = false;
            buttonCountTracking.buttonCount = 0;
        }
    }
    private void fileWrite()
    {
        filewriter = new StreamWriter(filewriteLocation + userId + "_" + currentSceneName + ".txt");
        filewriter.WriteLine("Number of Buttons Pressed during Gameplay");
        filewriter.WriteLine("Userd Id: " + userId);
        filewriter.WriteLine("Scene Name: " + currentSceneName);
        filewriter.WriteLine("Button Pressed Count : " + buttonPressedCount);
        filewriter.Flush();
        filewriter.Close();
    }
}
