using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighInteractionGuide : MonoBehaviour
{
    // Start is called before the first frame update
    private bool startPlaying;
    public static bool startFire;
    public AudioSource secondClueAudio;
    private bool audioFinished;
    private float timer;
    void Start()
    {
        startPlaying = true;
        audioFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<AudioSource>().isPlaying || secondClueAudio.isPlaying)
            startPlaying = false;
        else
            startPlaying = true;
        if(audioFinished == true)
        {
            timer += Time.deltaTime;
            if(timer >= this.GetComponent<AudioSource>().clip.length)
            {
                startFire = true;
                audioFinished = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(startPlaying == true && Music_System_Trigger.discFound == false)
        {
            this.GetComponent<AudioSource>().Play();
            audioFinished = true;
        }
        if (startPlaying == true && Music_System_Trigger.discFound == true && switchBoard_Trigger.switchPressed == false)
            secondClueAudio.Play();
    }
}
