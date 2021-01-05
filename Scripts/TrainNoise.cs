using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goodsTrain;
    public GameObject SBahn;
    public AudioSource goodsTrainAudio;
    public AudioSource SBahnAudio;
    private bool sBahnStart;
    private bool goodsTrainStart;
    public GameObject sBahnsource, sBahnDestination, goodsSource, goodsDestination;
    private float speed = 0.9f;
    private float timer;
    private bool enableVibration;
    private float vibrationTimer;
    void Start()
    {
        enableVibration = false;
        sBahnStart = true;
        goodsTrainStart = false;
        timer = 0;
        vibrationTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sBahnStart == true && goodsTrainStart == false)
        {
            SBahn.transform.position = Vector3.MoveTowards(SBahn.transform.position, sBahnDestination.transform.position, speed);
            if(SBahn.transform.position == sBahnDestination.transform.position)
            {
                sBahnStart = false;
                goodsTrainStart = true;
                SBahn.transform.position = sBahnsource.transform.position;
            }
        }
        else if(sBahnStart == false && goodsTrainStart == true)
        {
            timer += Time.deltaTime;
            if(timer > 10)
            {
                goodsTrain.transform.position = Vector3.MoveTowards(goodsTrain.transform.position, goodsDestination.transform.position, (speed+ 0.4f));
                if(goodsTrain.transform.position == goodsDestination.transform.position)
                {
                    sBahnStart = true;
                    goodsTrainStart = false;
                    goodsTrain.transform.position = goodsSource.transform.position;
                    timer = 0;
                }
            }
        }
        if(enableVibration == true && vibrationTimer <=10)
        {
            vibrationTimer += Time.deltaTime;
            OVRInput.SetControllerVibration(0.5f, 0.7f, OVRInput.Controller.All);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.tag == "SBahn")
        {
            speed = 0.5f;
            SBahnAudio.Play();
        }   
     else if(other.gameObject.tag == "GoodsTrain")
        {
            speed = 0.5f;
            goodsTrainAudio.Play();
            enableVibration = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SBahn")
        {
            SBahnAudio.Stop();
            speed = 0.9f;
        }
        else if(other.gameObject.tag == "GoodsTrain")
        {
            goodsTrainAudio.Stop();
            speed = 0.9f;
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.All);
            enableVibration = false;
        }
    }
}
