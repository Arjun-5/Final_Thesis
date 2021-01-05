using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationTrigger_New : MonoBehaviour
{
    //Used for Continuous Noise Scene
    // Start is called before the first frame update
    public static bool animationStart;
    //public AudioSource introAudio;
    private float audioposition;
    private bool audio_trigger;
    public AudioSource musicAudio;
    public AudioSource introContinuousMusic;
    private bool danceTriggered;
    public Light mainLght;
    public GameObject danceFloorLights;
    public Light discoBallLight;
    public GameObject discoBall;
    private float ballrotationAngle;
    void Start()
    {
        audioposition = 0;
        animationStart = false;
        audio_trigger = false;
        danceTriggered = false;
        danceFloorLights.SetActive(false);
        discoBallLight.enabled = false;
        ballrotationAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((switchBoard_Trigger.switchPressed == true && Music_System_Trigger.discFound == true) || Input.GetKeyDown(KeyCode.L))
        {
            if (animationStart == false)
            {
                mainLght.enabled = false;
                danceFloorLights.SetActive(true);
                animationStart = true;
                audio_trigger = false;
                introContinuousMusic.Stop();
                musicAudio.Play();
                discoBallLight.enabled = true;
            }
        }
        if(discoBallLight.enabled == true)
        {
            ballrotationAngle += (Time.deltaTime * 30);
            discoBall.transform.localRotation = Quaternion.Euler(0, ballrotationAngle, 0);    
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(danceTriggered == false && (other.gameObject.name == "OVRPlayerController" || other.gameObject.tag =="Player"))
        {
            //introAudio.Play();
            audio_trigger = true;
            danceTriggered = true;
        }
    }
}
