using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public GameObject flipper_L;
    public GameObject flipper_R;    

    public float restPosition = 0f;
    public float maxLeftFlipperPosition= -65f;
    public float maxRightFlipperPosition= 65f;
    public float hitStrenght = 9000f;
    public float flipperDamper = 150f;

    JointSpring leftFlipperSpring;
    JointSpring rightFlipperSpring;

    HingeJoint leftFlipperHinge;
    HingeJoint rightFlipperHinge;

    private void Start()
    {
        flipper_L = GameObject.Find("Flipper_L");
        flipper_R = GameObject.Find("Flipper_R");

        leftFlipperHinge = flipper_L.GetComponent<HingeJoint>();
        leftFlipperHinge.useSpring = true;

        rightFlipperHinge = flipper_R.GetComponent<HingeJoint>();
        rightFlipperHinge.useSpring = true;

        leftFlipperSpring = new JointSpring
        {
            spring = hitStrenght,
            damper = flipperDamper
        };

        rightFlipperSpring = new JointSpring
        {
            spring = hitStrenght,
            damper = flipperDamper
        };        
    }
        
    void Update()
    {
        leftFlipperHinge.spring = leftFlipperSpring;
        rightFlipperHinge.spring = rightFlipperSpring;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftFlipperSpring.targetPosition = maxLeftFlipperPosition;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftFlipperSpring.targetPosition = restPosition;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightFlipperSpring.targetPosition = maxRightFlipperPosition;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightFlipperSpring.targetPosition = restPosition;
        }        
    }
}
