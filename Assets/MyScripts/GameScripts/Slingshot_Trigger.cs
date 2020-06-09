using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot_Trigger : MonoBehaviour
{
    public Transform parentController;
    public Rigidbody ballRb;
    
    void Start()
    {
        this.parentController = this.transform.parent;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            Debug.Log("Ball entered!");

            this.ballRb = c.gameObject.GetComponent<Rigidbody>();
            parentController.GetComponent<SlingshotController>().NotifyBallEnter(ballRb);            
        }
    }        
}
