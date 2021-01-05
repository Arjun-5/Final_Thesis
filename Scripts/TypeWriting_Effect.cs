using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypeWriting_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 2;
    public string text_to_Display;
    private string currentText = "";
    private bool writingComplete = false;
    void Start()
    {
    }
    void Update()
    {
        if (StartButtonAction.buttonPressed == true && writingComplete == false)
        {
            Debug.Log("Here");
            StartCoroutine("writeText");
        }
    }
    IEnumerator writeText()
    {
        for (int i = 0; i < text_to_Display.Length; i++)
        {
            currentText = text_to_Display.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        writingComplete = true;
    }
}
