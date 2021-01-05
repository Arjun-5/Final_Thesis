using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering_Light : MonoBehaviour
{
    // Start is called before the first frame update
    public Light lightsource;
    private float miniTime, maxTime, timer;
    public GameObject audioObject;
    private AudioSource lightAudio;
    void Start()
    {
        miniTime = 0.1f;
        maxTime = 1.8f;
        timer = Random.Range(miniTime, maxTime);
        lightAudio = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FlickeringLight();
    }
    void FlickeringLight()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            lightsource.enabled = !lightsource.enabled;
            timer = Random.Range(miniTime, maxTime);
            lightAudio.Play();
        }
    }
}
