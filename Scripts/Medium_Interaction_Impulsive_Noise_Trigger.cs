using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium_Interaction_Impulsive_Noise_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool glassShatter;
    public GameObject mug;
    public GameObject brokenMug;
    private GameObject[] brokenMugParts;
    public GameObject shaeCharacter;
    private bool walkingStart;
    public Transform secondPoint;
    private bool secondPositionStart;
    private bool pieceExecuted;
    public GameObject brokenGlass;
    public Transform breakingPoint;
    private float distance;
    public AudioSource brokenMug_Audio;
    private bool lastCheck;
    void Start()
    {
        glassShatter = false;
        brokenMugParts = GameObject.FindGameObjectsWithTag("Mug_Parts");
        foreach(GameObject brokenMugPart in brokenMugParts)
        {
            brokenMugPart.GetComponent<BoxCollider>().enabled = false;
        }
        brokenMug.SetActive(false);
        walkingStart = false;
        secondPositionStart = false;
        pieceExecuted = false;
        lastCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(brokenGlass.transform.position, breakingPoint.position);
        if(buttonMovement.currentCoinCount >= 16 && buttonMovement.currentCoinCount < 18 && glassShatter == false)
        {
            foreach (GameObject brokenMugPart in brokenMugParts)
            {
                brokenMugPart.GetComponent<Rigidbody>().useGravity = true;
            }
            glassShatter = true;
            mug.SetActive(false);
            brokenMug.SetActive(true);
        }
        //16 and 17
        if (buttonMovement.currentCoinCount == 16 || buttonMovement.currentCoinCount == 17)
        {
            walkingStart = true;
        }
        if(walkingStart == true && secondPositionStart == false)
        {
            if(pieceExecuted == false)
            {
                shaeCharacter.GetComponent<Animator>().SetBool("Walking_Start", true);
                pieceExecuted = true;
            }
            shaeCharacter.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            if (shaeCharacter.transform.position != secondPoint.position)
            {
                shaeCharacter.transform.position = Vector3.MoveTowards(shaeCharacter.transform.position, secondPoint.position, 0.01f);
            }
        }
        if(shaeCharacter.transform.position == secondPoint.position)
        {
            shaeCharacter.GetComponent<Animator>().SetBool("Walking_Start", false);
        }
        if (glassShatter == true && distance <= 0.156f && lastCheck == false)
        {
            lastCheck = true;
            foreach (GameObject brokenMugPart in brokenMugParts)
            {
                brokenMugPart.GetComponent<BoxCollider>().enabled = true;
            }
            brokenMug_Audio.Play();
        }
    }

}
