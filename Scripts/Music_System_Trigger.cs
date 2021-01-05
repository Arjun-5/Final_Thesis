using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Music_System_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject disc1, disc2, disc_prop1, disc_prop2;
    public static bool discFound;
    private bool status1, status2;
    void Start()
    {
        status1 = false;
        status2 = false;
        disc1.SetActive(false);
        disc2.SetActive(false);
        discFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(status1 ==true && status2 == true)
        {
            status1 = false;
            status2 = false;
            discFound = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Disc_Prop_1")
        {
            disc_prop1.SetActive(false);
            disc1.SetActive(true);
            status1 = true;
        } 
        else if( other.gameObject.name == "Disc_Prop_2")
        {
            disc_prop2.SetActive(false);
            disc2.SetActive(true);
            status2 = true;
        }        
    }
}
