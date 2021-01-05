using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    public Text descriptionText;
    private bool startMemoryGame;
    public GameObject button;
    private float timer;
    public GameObject gameChips;
    void Start()
    {
        timerText.text = "240.00";
        startMemoryGame = false;
        button.GetComponent<Animator>().enabled = false;
        timer = 240.00f;
    }

    // Update is called once per frame
    void Update()
    {
        if(startMemoryGame == true)
        {
            timer -= Time.deltaTime;
            button.GetComponent<Animator>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = false;
            timerText.text = timer.ToString("F2");
        }
        if(timer < 0 && ImageGame.foundAll != 30)
        {
            gameChips.SetActive(false);
            startMemoryGame = false;
            timerText.text = "00:00";
            descriptionText.text = "Oopsie!!!, Please ,concentrate on the task hand.";
        }
        else if(timer >=0 && ImageGame.foundAll == 30)
        {
            startMemoryGame = false;
            descriptionText.text = "Congratulations!!!, You are really attentive.";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hands")
        {
            button.GetComponent<Animator>().enabled = true;
            startMemoryGame = true;
            descriptionText.text = "Good Luck!!Game Started";
        }
    }
}
