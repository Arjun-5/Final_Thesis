using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject point1_Object;
    public GameObject point4_Object;
    public Transform point4_Trigger;
    private float speed;
    private bool movementComplete;
    void Start()
    {
        speed = 0.1f;
        movementComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (otherVehcileMovement.allDestinationReached == true && movementComplete == false)
        {
            point1_Object.transform.position = Vector3.MoveTowards(point1_Object.transform.position, this.transform.position, speed);
            point4_Object.transform.position = Vector3.MoveTowards(point4_Object.transform.position, point4_Trigger.position, speed * 2);
            if (point1_Object.transform.position == this.transform.position & point4_Object.transform.position == point4_Trigger.position)
            {
                movementComplete = true;
            }
        }
    }
}
