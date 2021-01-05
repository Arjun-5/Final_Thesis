using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBoard_Trigger : MonoBehaviour
{
    public static bool switchPressed;
    // Start is called before the first frame update
    private void Start()
    {
        switchPressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.localRotation = Quaternion.Euler(-105f, 0f, 0f);
        switchPressed = true;
    }
}
