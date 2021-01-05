using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowNoiseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    private float windowOpentimer;
    public GameObject windowPivot;
    public GameObject ambulancePosition;
    public GameObject ambulance_destination;
    public AudioSource rain_and_Thunder;
    public AudioSource lightingImpulsive;
    public AudioSource windowShut;
    private bool lightingPlayed;
    private bool windowShutPlayed;
    void Start()
    {
        timer = 0;
        rain_and_Thunder.enabled = false;
        lightingImpulsive.enabled = false;
        lightingPlayed = false;
        windowPivot.GetComponent<Animator>().enabled = false;
        windowShutPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ambulancePosition.transform.position == ambulance_destination.transform.position && rain_and_Thunder.enabled == false)
        {
            rain_and_Thunder.enabled = true;
            rain_and_Thunder.Play();
        }
        if (rain_and_Thunder.enabled == true && lightingPlayed == false)
            timer += Time.deltaTime;
        if (timer >= 15)
        {
            lightingImpulsive.enabled = true;
            lightingImpulsive.Play();
            timer = 0;
            lightingPlayed = true;
        }
        if(lightingPlayed == true && lightingImpulsive.isPlaying == false && windowShutPlayed == false)
        {
            windowOpentimer += Time.deltaTime;
            if(windowOpentimer >= 25)
            {
                windowPivot.GetComponent<Animator>().enabled = true;
                windowShut.enabled = true;
                windowShut.Play();
                windowShutPlayed = true;
            }
        }
    }
 
}
