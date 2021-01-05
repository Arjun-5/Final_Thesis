using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.4)
        {
            GetComponent<Text>().enabled = true;
        }
        if(timer >= 0.8)
        {
            GetComponent<Text>().enabled = false;
            timer = 0;
        }
    }
}
