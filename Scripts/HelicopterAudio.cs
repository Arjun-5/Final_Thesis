using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource helicopterSound;
    public AudioSource aeroplaneSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Helicopter")
        {
            helicopterSound.Play();
        }
        if(other.tag == "Boeing")
        {
            aeroplaneSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Helicopter")
        {
            helicopterSound.Stop();
        }
    }
}
