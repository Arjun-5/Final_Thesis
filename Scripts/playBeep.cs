using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBeep : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool CanWrite;
    void Start()
    {
        CanWrite = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(loadMainMenu.loadedagain == true)
        {
            this.GetComponent<AudioSource>().Play();
            loadMainMenu.loadedagain = false;
            CanWrite = true;
        }
    }
}
