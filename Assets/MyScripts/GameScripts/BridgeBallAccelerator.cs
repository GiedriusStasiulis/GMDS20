using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBallAccelerator : MonoBehaviour
{
    public Rigidbody ballRb;
    public float forceAmount;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            Debug.Log("Ball entered!");

            ballRb = c.gameObject.GetComponent<Rigidbody>();        
            ballRb.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
        }
    }  
}
