using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newsAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource introAudio;
    private bool audioStarted;
    private float timer;
    private bool introStarted;
    void Start()
    {
        introAudio.enabled = false;
        GetComponent<AudioSource>().enabled = false;
        audioStarted = false;
        introStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 20 && introStarted == false)
        {
            introAudio.enabled = true;
            introStarted = true;
        }
        if(introAudio.isPlaying == false && audioStarted == false && introStarted == true)
        {
            GetComponent<AudioSource>().enabled = true;
            audioStarted = true;
        }
    }
}
