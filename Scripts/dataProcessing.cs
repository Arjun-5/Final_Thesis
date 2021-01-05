using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class dataProcessing : Ray_From_Controller
{
    // Start is called before the first frame update
    private GameObject[] answerPoints;
    private string filewriteLocation;
    public Material optionAnswer;
    public Material optionDefault;
    private string[] choosenOption;
    private StreamWriter filewriter;

    public override void Start()
    {
        base.Start();
        rayLength = 3000.0f;
        pointerRing.transform.localScale = new Vector3(10f, 10f, 10f);
        lineRenderer = GetComponent<LineRenderer>();
        choosenOption = new string[10];
        filewriteLocation = Application.persistentDataPath + "/Questionnaire/";
        filewriter = new StreamWriter(filewriteLocation + "Questionnaire_1.txt");
    }
    public override void Update()
    {
        base.updateLength();
    }
    protected override void checkHit()
    {
        RaycastHit hit = base.createForwardRayCast();
        if (hit.collider.gameObject.tag == "Questionnaire_Element" || hit.collider.gameObject.tag == "Submit_Element")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1 && hit.collider.gameObject.tag == "Submit_Element") || Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (!Directory.Exists(filewriteLocation))
                {
                    Directory.CreateDirectory(filewriteLocation);
                    fileWrite();
                }
                else
                    fileWrite();
            }
        }
        else
        {
            pointerRing.SetActive(false);
        }
        if(hit.collider.tag == "Question_1")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1){
                answerPoints = GameObject.FindGameObjectsWithTag("Question_1");
                foreach (GameObject answerPoint in answerPoints)
                {
                    answerPoint.GetComponent<Renderer>().material = optionDefault;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material = optionAnswer;
                choosenOption[0] = hit.collider.gameObject.transform.parent.name;
            }
        }
        else if(hit.collider.tag == "Question_2")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
            {
                answerPoints = GameObject.FindGameObjectsWithTag("Question_2");
                foreach (GameObject answerPoint in answerPoints)
                {
                    answerPoint.GetComponent<Renderer>().material = optionDefault;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material = optionAnswer;
                choosenOption[1] = hit.collider.gameObject.transform.parent.name;
            }
        }
        else if (hit.collider.tag == "Question_3")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
            {
                answerPoints = GameObject.FindGameObjectsWithTag("Question_3");
                foreach (GameObject answerPoint in answerPoints)
                {
                    answerPoint.GetComponent<Renderer>().material = optionDefault;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material = optionAnswer;
                choosenOption[2] = hit.collider.gameObject.transform.parent.name;
            }
        }
        else if (hit.collider.tag == "Question_4")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
            {
                answerPoints = GameObject.FindGameObjectsWithTag("Question_4");
                foreach (GameObject answerPoint in answerPoints)
                {
                    answerPoint.GetComponent<Renderer>().material = optionDefault;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material = optionAnswer;
                choosenOption[3] = hit.collider.gameObject.transform.parent.name;
            }
        }
        else if (hit.collider.tag == "Question_5")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
            {
                answerPoints = GameObject.FindGameObjectsWithTag("Question_5");
                foreach (GameObject answerPoint in answerPoints)
                {
                    answerPoint.GetComponent<Renderer>().material = optionDefault;
                }
                hit.collider.gameObject.GetComponent<Renderer>().material = optionAnswer;
                choosenOption[4] = hit.collider.gameObject.transform.parent.name;
            }
        }

    }
    private void fileWrite()
    {
        filewriter.WriteLine("System Usability Scale");
        filewriter.WriteLine("");

        filewriter.WriteLine("1. I think I would like to use this device frequently : " + choosenOption[0] + " \n\n");
        filewriter.WriteLine("2. I found the application unnecessarily complex : " + choosenOption[1] + " \n\n");
        filewriter.WriteLine("3. I thought the application was easy to use : " + choosenOption[2] + " \n\n");
        filewriter.WriteLine("4. I think that I would need the support of a technical person to be able to use this system: : " + choosenOption[3] + " \n\n");
        filewriter.WriteLine("5. I found the various functions in this application were well integrated : " + choosenOption[4] + " \n\n");
        filewriter.Flush();
        filewriter.Close();
    }
}