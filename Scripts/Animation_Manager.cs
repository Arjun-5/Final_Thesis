using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator refAnimator;
    private float timer;
    private int index;
    private float timeToWait = 19.0f;
    private string[] animationTrigger =
        { "Standing_Initial", "Is_BreakDance_Ready","Is_HipHop_0", "Is_HipHop_1","Is_HipHop_2","Is_HipHop_3",
        "Is_HipHop_4","Breakdance_Uprock","Macarena", "Shuffling","Silly_Dancing_1","Silly_Dancing_2"};

    void Start()
    {
        timer = 0;
        index = 0;
        refAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StartAnimationTrigger.animationStart == true || StartAnimationTrigger_New.animationStart == true)
        {
            timer += Time.deltaTime;
            if ((timer >= timeToWait && index <= animationTrigger.Length) && animationTrigger[index] != "Standing_Initial")
            {
                refAnimator.SetBool(animationTrigger[index], false);
                index += 1;
                timer = 0;
            }
            else if (animationTrigger[index] == "Standing_Initial")
            {
                if(timer >= 1.0f)
                {
                    refAnimator.SetBool(animationTrigger[index], false);
                    index += 1;
                    timer = 0;
                }
            }
        }    
    }
}
