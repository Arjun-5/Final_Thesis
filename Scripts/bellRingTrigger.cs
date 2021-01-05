using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellRingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool alarmClock;
    public AudioSource analogAlarm;
    private float movementAngle;
    private bool startAnimation;
    private bool directionForward;
    public static bool hornCanPlay;
    public static GameObject carGameObject;
    public Transform intermediateLocation;
    void Start()
    {
        alarmClock = false;
        movementAngle = -2f;
        startAnimation = false;
        directionForward = true;
        hornCanPlay = false;
        carGameObject = GameObject.Find("Car_Props/HondaCar");
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonMovement.currentCoinCount >= 4 && buttonMovement.currentCoinCount <6 && alarmClock == false)
        {
            alarmClock = true;
            analogAlarm.Play();
            startAnimation = true;
        }
        if(startAnimation == true)
        {
            if (directionForward == true)
            {
                movementAngle += 3.0f;
                if (movementAngle >= 23f)
                    directionForward = false;
            }
            if (directionForward == false)
            {
                movementAngle -= 3.0f;
                if (movementAngle <= -2f)
                    directionForward = true;
            }
            this.transform.localRotation = Quaternion.Euler(0, 0, movementAngle);
        }
        if (buttonMovement.currentCoinCount >= 8 && hornCanPlay == false)
        {
            analogAlarm.Stop();
            startAnimation = false;
            carGameObject.transform.position = Vector3.MoveTowards(carGameObject.transform.position, intermediateLocation.position, 0.35f);
        }
        if(buttonMovement.currentCoinCount >= 12 && buttonMovement.currentCoinCount < 14 && hornCanPlay == false)
        {
            hornCanPlay = true;
        }
    }
}
