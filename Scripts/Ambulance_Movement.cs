using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ambulance;
    private float speed = 0.4f;
    public GameObject destination;
    public GameObject midPoint;
    public AudioSource siren;
    public static bool windowShutTrigger;
    void Start()
    {
        windowShutTrigger = true;
        siren.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ambulance.transform.position != midPoint.transform.position)
            Ambulance.transform.position = Vector3.MoveTowards(Ambulance.transform.position, destination.transform.position, speed);
        else
        {
            if(siren.isPlaying == false)
            Ambulance.transform.position = Vector3.MoveTowards(Ambulance.transform.position, destination.transform.position, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Ambulance.transform.position = midPoint.transform.position;
        siren.enabled = true;
        siren.Play();
    }

}
