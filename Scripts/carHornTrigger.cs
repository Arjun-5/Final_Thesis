using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carHornTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform finalDestination;
    public AudioSource carHorn;
    // Update is called once per frame
    void Update()
    {
        if(bellRingTrigger.hornCanPlay == true)
        {
            bellRingTrigger.carGameObject.transform.position = Vector3.MoveTowards(bellRingTrigger.carGameObject.transform.position, finalDestination.position, 0.2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        carHorn.Play();
    }
}
