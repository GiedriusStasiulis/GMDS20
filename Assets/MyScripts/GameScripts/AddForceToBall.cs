using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToBall : MonoBehaviour
{
    public Rigidbody ballRb;
    public float forceAmount;

    public Vector3 lastPos;

    private void Awake()
    {
        this.ballRb = this.GetComponent<Rigidbody>();   // Cache
    }

    private void ApplyPush()
    {
        this.StartCoroutine(this.DoApplyPush());    
    }

    private IEnumerator DoApplyPush()
    {
        // Get the position then move to the next frame
        this.lastPos = this.ballRb.position;
        yield return null;  // continue next frame
        
        // Get the motion vector which is a vector from last frame to this frame.
        Vector3 motionVect = this.ballRb.position - this.lastPos; 

        // ... Do stuff ...
        // No idea if this will work, just based on docs
        ballRb.AddForce(motionVect.normalized * this.forceAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed!");
            ApplyPush();
        }
    }
}
