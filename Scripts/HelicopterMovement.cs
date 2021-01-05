using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform helicopterEnd;
    void Update()
    {
        if(this.gameObject.transform.position != helicopterEnd.position && StartButtonAction.gameStarted == true)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, helicopterEnd.position, 0.2f);
        }
    }
}
