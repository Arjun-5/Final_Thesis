using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture openTexture;
    public GameObject cardReader;
    private bool doorOpen;
    public GameObject rightDoor;
    public GameObject leftDoor;
    void Start()
    {
        doorOpen = false;
        rightDoor.GetComponent<Animator>().enabled = false;
        leftDoor.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen == true || Input.GetKeyDown(KeyCode.Comma))
        {
            rightDoor.GetComponent<Animator>().enabled = true;
            leftDoor.GetComponent<Animator>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KeyCard")
        {
            this.GetComponent<AudioSource>().Play();
            cardReader.GetComponent<Renderer>().material.mainTexture = openTexture;
            doorOpen = true;
        }
    }
}
