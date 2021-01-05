using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTruckMovement : MonoBehaviour
{
    private bool fireTruckStart;
    private bool fireTruckAlarm;
    public GameObject fireParticle;
    private float timer;
    public GameObject fireTruckObject;
    public Transform fireTruckDestination;
    public Transform finalDestination;
    public AudioSource fireEngineSound;
    public GameObject waterParticle;
    public AudioSource waterSpray;
    private bool enablewaterSpray;
    private bool secondMovement;
    // Start is called before the first frame update
    void Start()
    {
        fireTruckStart = false;
        fireParticle.SetActive(false);
        timer = 0;
        waterParticle.SetActive(false);
        fireTruckAlarm = false;
        enablewaterSpray = false;
        secondMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTruckStart == false && HighInteractionGuide.startFire == true)
        {
            fireParticle.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            fireTruckStart = true;
            fireTruckAlarm = true;
        }
        if(fireTruckAlarm == true)
        {
            timer += Time.deltaTime;
            if (timer > 20)
            {
                fireEngineSound.Play();
                this.GetComponent<AudioSource>().Stop();
                fireTruckAlarm = false;
            }
        }
        if(fireTruckAlarm == false && fireTruckStart == true && secondMovement == false)
        {
            fireTruckObject.transform.position = Vector3.MoveTowards(fireTruckObject.transform.position, fireTruckDestination.position, 0.7f);
        }
        if(fireTruckObject.transform.position == fireTruckDestination.position && enablewaterSpray == false)
        {
            secondMovement = true;
            waterParticle.SetActive(true);
            fireEngineSound.Stop();
            enablewaterSpray = true;
            timer = 0;
            waterSpray.Play();
        }
        if(enablewaterSpray == true && secondMovement == true)
        {
            timer += Time.deltaTime;
            if(timer > 20)
            {
                waterSpray.Stop();
                fireParticle.SetActive(false);
                waterParticle.SetActive(false);
                fireTruckObject.transform.position = Vector3.MoveTowards(fireTruckObject.transform.position, finalDestination.position, 0.2f);
                if (fireTruckObject.transform.position == finalDestination.position)
                    enablewaterSpray = false;
            }
        }
    }
}
