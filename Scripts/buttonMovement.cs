using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMovement : OVRGrabbable
{
    //To check if the button is grabbed
    private bool buttonGrabbed = false;
    
    //Get the buttonRig to which the rotation values should be applied
    public GameObject buttonRig;

    //Total coins count used in the game
    private const int coinCount = 20;

    //Coin start value
    public static int currentCoinCount = 0;

    //User always starts playing first
    private bool userPlaying = true;

    //Used for tracking the game Status
    private bool gameOver = false;

    //Used to set the winner text
    public GameObject winnerText;

    //Track who is playing currently
    public GameObject playerTracker;

    //boolean to limit the coroutine call from Update function
    private float timer = 0;

    //Random Number
    private int randomNumber = 0;
    void Update()
    {
        //Enter the loop when the user is playing and also when the game is not yet over
        if (userPlaying == true && gameOver == false)
        {
            /*Check if the controller in the arcade machine is grabbed by the Custom oculus hand
             and if the user is pressing Button A in the right Oculus Controller*/
            if ((buttonGrabbed == true && OVRInput.Get(OVRInput.Button.One)) || Input.GetKey(KeyCode.C))
            {
                //Set the rig to rotate around Z-Axis by 30 degree
                buttonRig.transform.localRotation = Quaternion.Euler(0f, 0f, 15f);

                //Add a delay of 3 seconds before performing the next function call
                //StartCoroutine(addDelay());

                trackProgress(2);
            }
            else if ((buttonGrabbed == true && OVRInput.Get(OVRInput.Button.Two)) || Input.GetKey(KeyCode.B))
            {
                buttonRig.transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
                trackProgress(1);               
            }
        }
        else if (userPlaying == false && gameOver == false)
        {
            //Set the display text to notify the user that the computer is playing
            playerTracker.GetComponent<Text>().text = "Maintain patience, Computer is thinking!!!";

            //This ensures that the coroutine is called only once and not the times per frame
            timer += Time.deltaTime;

            //Call the track progress method with the index value being generated randomly            
            if(timer >= 3)
            {
                if((coinCount - currentCoinCount) <= 2)
                {
                    int leftOverCoin = coinCount - currentCoinCount;
                    trackProgress(leftOverCoin);
                }
                else
                {
                    randomNumber = Random.Range(1, 99999);
                    randomNumber = (randomNumber % 2) + 1;
                    trackProgress(randomNumber);
                    timer = 0;
                    if(buttonRig.transform.localRotation.z == -15f)
                    {
                        buttonRig.transform.localRotation = Quaternion.Euler(0f, 0f, 15f);
                    }
                    else if(buttonRig.transform.localRotation.z == 15f)
                    {
                        buttonRig.transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Right_Hand" || other.gameObject.tag == "Left_Hand" || Input.GetKey(KeyCode.A))
        {
            buttonGrabbed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Right_Hand" || other.gameObject.tag == "Left_Hand")
        {
            buttonGrabbed = false;
        }
    }
    void trackProgress(int index)
    {
        GameObject coin;
        if (index == 1)
        {
            //Increase the current coin count by 1 and call the hidecoins function
            currentCoinCount += 1;
            coin = GameObject.Find("Coin_" + currentCoinCount);
            coin.SetActive(false);
        }
        else if (index == 2)
        {
            //Increase the current coin count by 2 and call the hidecoins function
            for(int i = 0; i < 2; i++)
            {
                currentCoinCount += 1;
                coin = GameObject.Find("Coin_" + currentCoinCount);
                coin.SetActive(false);
            }
        }
        if(currentCoinCount >= coinCount)
        {
            //If current coin count is 20 then set the gameover value to true and call determineWinner function
            gameOver = true;
            playerTracker.SetActive(false);
            determineWinner();
        }
        else
        {
            //Set the next player to User or Computer accordingly
            if (userPlaying == true)
            {
                userPlaying = false;
            }
            else
            {
                userPlaying = true;
                //Then reset the rig to rotate back to it original position
                playerTracker.GetComponent<Text>().text = "Your turn!!!";
            }
        }
    }
    void determineWinner()
    {
        if(userPlaying == false)
        {
            winnerText.SetActive(true);
            winnerText.gameObject.GetComponent<Text>().text = "Game Over!! You lost";
        }
        else if(userPlaying == true)
        {
            winnerText.SetActive(true);
            winnerText.gameObject.GetComponent<Text>().text = "Hurray!! You win";
        }
        StartButtonAction.buttonPressed = false;
    }
}