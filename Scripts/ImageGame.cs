using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageGame : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject firstObjectSelected, secondObjectSelected;
    private bool selectedOne, selectedTwo;
    private GameObject[] disableObjects;
    public static int foundAll;
    private List<GameObject> selectedObjects = new List<GameObject>();
    void Start()
    {
        selectedOne = false;
        selectedTwo = false;
        foundAll = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print("Size of the list : " + selectedObjects.Count);
        if(selectedObjects.Count == 2)
        {
            if(selectedObjects[1].tag != selectedObjects[2].tag)
            {
                selectedObjects[1].GetComponent<Animator>().SetBool("Chip_Rotation", false);
                selectedObjects[2].GetComponent<Animator>().SetBool("Chip_Rotation", false);
            }
            else
            {
                disableObjects = GameObject.FindGameObjectsWithTag(selectedObjects[1].tag);
                foreach (GameObject element in disableObjects)
                {
                    element.GetComponent<BoxCollider>().enabled = false;
                    foundAll += 1;
                }
            }
            selectedObjects.Clear();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Hands" && selectedObjects.Count < 2)
        {
            selectedObjects.Add(this.gameObject);
            this.GetComponent<Animator>().SetBool("Chip_Rotation", true);
        }
    }
}
