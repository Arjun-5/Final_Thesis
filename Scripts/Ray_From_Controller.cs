using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ray_From_Controller : MonoBehaviour
{
    protected float lineLength = 0.5f;
    protected float rayLength = 3000.0f;
    protected LineRenderer lineRenderer;
    public GameObject pointerRing;
    protected Vector3 ringOffset;
    public AudioSource introMusic;
    public AudioSource introAudio;
    private SceneManager sceneName;
    public static string loadedScene;
    AsyncOperation sceneToLoad;
    public static bool sceneLoadComplete;
    public virtual void Start()
    {
        ringOffset = new Vector3(0f, 0f, 3.0f);
        lineRenderer = GetComponent<LineRenderer>();
        pointerRing.SetActive(false);
        sceneLoadComplete = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        updateLength();
    }
    public virtual void updateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, DefaultEnd(lineLength));
        checkHit();
    }
    protected virtual void checkHit()
    {
        RaycastHit hit = createForwardRayCast();
        if (hit.collider.gameObject.tag == "Zero_Int_C" || hit.collider.gameObject.tag == "Zero_IMP" || hit.collider.gameObject.tag == "Zero_Int_I" || hit.collider.gameObject.tag == "Zero_Int_LF" || hit.collider.gameObject.tag == "Med_Int_C" || hit.collider.gameObject.tag == "Med_Int_Imp" || hit.collider.gameObject.tag == "Med_Int_I" || hit.collider.gameObject.tag == "Med_Int_LF" || hit.collider.gameObject.tag == "High_Int_C" || hit.collider.gameObject.tag == "High_Int_Imp" || hit.collider.gameObject.tag == "High_Int_I" || hit.collider.gameObject.tag == "High_Int_LF" || hit.collider.gameObject.tag =="Scene_Mode" || hit.collider.gameObject.tag =="Introduction_Element" || hit.collider.gameObject.tag == "SUS")
        {
            pointerRing.SetActive(true);
            pointerRing.transform.localPosition = hit.point - ringOffset;
            pointerRing.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1) 
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Zero_Int_C":
                        StartCoroutine(LoadYourAsyncScene("Zero_Interaction_Continuous"));
                        break;
                    case "Zero_IMP":
                        StartCoroutine(LoadYourAsyncScene("Zero_Interaction_Impulsive"));
                        break;
                    case "Zero_Int_I":
                        StartCoroutine(LoadYourAsyncScene("Zero_Interaction_Intermittent"));
                        break;
                    case "Zero_Int_LF":
                        StartCoroutine(LoadYourAsyncScene("Zero_Interaction_LowFrequency"));
                        break;
                    case "Med_Int_C":
                        StartCoroutine(LoadYourAsyncScene("Medium_Interaction_Continuous_Noise"));
                        break;
                    case "Med_Int_Imp":
                        StartCoroutine(LoadYourAsyncScene("Medium_Interaction_Impulsive_Noise"));
                        break;
                    case "Med_Int_I":
                        StartCoroutine(LoadYourAsyncScene("Medium_Interaction_Intermittent"));
                        break;
                    case "Med_Int_LF":
                        StartCoroutine(LoadYourAsyncScene("Medium_Interaction_LowFrequency"));
                        break;
                    case "High_Int_C":
                        StartCoroutine(LoadYourAsyncScene("High_Interaction_Continuous"));
                        break;
                    case "High_Int_Imp":
                        StartCoroutine(LoadYourAsyncScene("High_Interaction_Impulsive"));
                        break;
                    case "High_Int_I":
                        StartCoroutine(LoadYourAsyncScene("High_Interaction_Intermittent"));
                        break;
                    case "High_Int_LF":
                        StartCoroutine(LoadYourAsyncScene("High_Interaction_LowFrequency"));
                        break;
                    case "Introduction_Element":
                        introAudio.Play();
                        introMusic.Stop();
                        break;
                    case "Scene_Mode":
                        SceneManager.LoadScene("Scene_Mode", LoadSceneMode.Single);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            pointerRing.SetActive(false);
        }
            
    }
    protected RaycastHit createForwardRayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, rayLength);
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.green);
        return hit;
    }
    public Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * lineLength);
    }
    IEnumerator LoadYourAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        loadedScene = name;
        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                sceneLoadComplete = true;
            }
            yield return null;
        }
        // Wait until the asynchronous scene fully loads
        /*while (!asyncLoad.isDone)
        {
            yield return null;
            //yield return new WaitForSeconds(5); 
        }*/
        //yield return SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }
}
