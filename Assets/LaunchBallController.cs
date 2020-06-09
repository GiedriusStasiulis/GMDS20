using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBallController : MonoBehaviour
{
    public bool ballReady;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            Debug.Log("Ball is ready to be launched!");
            ballReady = true;
        }
    }    

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            Debug.Log("Ball was launched!");
            ballReady = false;
        }
    }
}
