using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_To_SceneMode : MonoBehaviour
{
    // Start is called before the first frame update
    private bool objectScaled;
    void Start()
    {
        objectScaled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1 || Input.GetKeyDown(KeyCode.Space)) && objectScaled == false)
        {
            this.GetComponent<Animator>().SetBool("Ipad_Scaling", true);
            objectScaled = true;
        }
        else if((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1 || Input.GetKeyDown(KeyCode.Space)) && objectScaled == true) 
        {
            this.GetComponent<Animator>().SetBool("Ipad_Scaling", false);
            objectScaled = false;
        }
    }
}
