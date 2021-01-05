using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherVehcileMovement : MonoBehaviour
{
    public GameObject point2_Object;
    public GameObject point3_Object;
    public GameObject point5_Object;
    public GameObject point6_Object;
    public Transform point2_Trigger;
    public Transform point3_Trigger;
    public Transform point5_Trigger;
    public Transform point6_Trigger;
    public static bool allDestinationReached;
    private float speed;
    public AudioSource trafficNoise;
    // Start is called before the first frame update
    void Start()
    {
        allDestinationReached = false;
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(allDestinationReached == false)
        {
            point2_Object.transform.position = Vector3.MoveTowards(point2_Object.transform.position, point2_Trigger.position, speed);
            point3_Object.transform.position = Vector3.MoveTowards(point3_Object.transform.position, point3_Trigger.position, speed);
            point5_Object.transform.position = Vector3.MoveTowards(point5_Object.transform.position, point5_Trigger.position, speed);
            point6_Object.transform.position = Vector3.MoveTowards(point6_Object.transform.position, point6_Trigger.position, speed);
            if (point2_Object.transform.position == point2_Trigger.position)
            {
                trafficNoise.Play();
                if(point3_Object.transform.position == point3_Trigger.position && point5_Object.transform.position == point5_Trigger.position && point6_Object.transform.position == point6_Trigger.position)
                {
                    allDestinationReached = true;
                }
            }
        }
        
    }
}
