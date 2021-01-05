using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCountTracking : MonoBehaviour
{
    public static int buttonCount;
    // Start is called before the first frame update
    void Start()
    {
        buttonCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Three) || OVRInput.GetDown(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 1 || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1 || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 1 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
        {
            buttonCount += 1;
        }
    }
}
