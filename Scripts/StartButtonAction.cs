using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonAction : MonoBehaviour
{
    public GameObject startButtonRig;
    public GameObject textObject;
    public static bool buttonPressed;
    public string text_to_Display;
    public string rules_Text;
    private string currentText = "";
    private float delayTime = 3f;
    public GameObject coinObjects;
    public GameObject rulesText;
    public GameObject turnTracker;
    public GameObject winnerText;
    public static bool gameStarted;
    private static bool startButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
        rulesText.SetActive(false);
        coinObjects.SetActive(false);
        turnTracker.SetActive(false);
        winnerText.SetActive(false);
        gameStarted = false;
        startButtonPressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right_Hand" && gameStarted == false && startButtonPressed == false)
        {
            startButtonPressed = true;
            //if (OVRInput.Get(OVRInput.Button.One))
            startButtonRig.transform.localPosition = new Vector3(-0.00191471f, 0.01043f, -0.0026476f);
            buttonPressed = true;
            textObject.GetComponent<ScreenText>().enabled = false;
            textObject.GetComponent<Text>().enabled = true;
            StartCoroutine("writeText");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Right_Hand")
        {
            startButtonRig.transform.localPosition = new Vector3(-0.00191471f, 0.01051f, -0.0026476f);
        }
    }
    IEnumerator writeText()
    {
        for (int i = 0; i < text_to_Display.Length; i++)
        {
            currentText = text_to_Display.Substring(0, i);
            textObject.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.13f);
        }
        yield return StartCoroutine(addDelay());
        yield return StartCoroutine("writeRulesText");
        delayTime = 6f;
        gameStarted = true;
        yield return StartCoroutine(addDelay());
        textObject.GetComponent<Text>().enabled = false;
        coinObjects.SetActive(true);
        rulesText.SetActive(true);
        turnTracker.SetActive(true);
    }
    IEnumerator writeRulesText()
    {
        for (int i = 0; i < rules_Text.Length; i++)
        {
            currentText = rules_Text.Substring(0, i);
            textObject.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.13f);
        }
    }
    IEnumerator addDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
