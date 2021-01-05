using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    AudioSource myAudio;
    float[] spectrum = new float[256];
    public Light[] lights;
    public Light discoLight;
    private float colorChangeTrigger;
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        colorChangeTrigger = 0f;
    }
    void Update()
    {
        colorChangeTrigger += Time.deltaTime;
        myAudio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
           for (int j = 0; j < lights.Length; j++)
            {
                lights[j].intensity = spectrum[i] * 10000000;
            }
            discoLight.intensity = spectrum[i] * 10000000;
        }
        if(colorChangeTrigger > 0.8f)
        {
            discoLight.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            colorChangeTrigger = 0f;
        }
    }
}