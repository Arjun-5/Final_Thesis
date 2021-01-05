using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aeroplaneMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform aeroplaneEnd;
    private bool aeroplaneStart;
    private void Start()
    {
        aeroplaneStart = false;
    }
    void Update()
    {
        if (buttonMovement.currentCoinCount == 10 || buttonMovement.currentCoinCount == 11)
            aeroplaneStart = true;

        if (this.gameObject.transform.position != aeroplaneEnd.position && aeroplaneStart == true)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, aeroplaneEnd.position, 0.35f);
        }
    }
}
