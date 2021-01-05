using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    // Start is called before the first frame update
    float rotationPoint;
    void Start()
    {
        rotationPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotationPoint += 25f;
        this.transform.localRotation = Quaternion.Euler(0, 112, rotationPoint);
    }
}
