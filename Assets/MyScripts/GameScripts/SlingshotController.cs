using System.Collections;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    public Rigidbody ballRb;
    public int forceAmount;
    public Vector3 lastPos;
    public int slingshotState;
    public Transform slingshotCollider;
    public float minPos;
    public float maxPos;
    public float speed;
    public float zPos;

    public bool invertedAxis;

    void Start()
    {
        slingshotCollider = this.transform.GetChild(1);
    }

    void Update()
    {
        zPos = slingshotCollider.localPosition.z;

        if (zPos < minPos)	
        {
            slingshotState = 2;
        }

        if (zPos >= maxPos && slingshotState == 2)
        {
            slingshotState = -1;
        }

        switch(slingshotState)
        {
            case 1:
                //Move capsule collider down
                ApplyPush();

                if(invertedAxis)
                {
                    slingshotCollider.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }

                else
                {
                    slingshotCollider.transform.Translate(Vector3.back * Time.deltaTime * speed);
                }

                break;
        
            case 2:
                //Move capsule collider up

                if(invertedAxis)
                {
                    slingshotCollider.transform.Translate(Vector3.back * Time.deltaTime * speed);
                }

                else
                {
                    slingshotCollider.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
                
                break;
        }
    }
    
    public void NotifyBallEnter(Rigidbody rb)
    {
        slingshotState = 1;
        this.ballRb = rb;
    }

    private void ApplyPush()
    {
        StartCoroutine(ApplyPushCoroutine());    
    }

    private IEnumerator ApplyPushCoroutine()
    {
        this.lastPos = this.ballRb.position;
        yield return null;         
        
        Vector3 motionVect = this.ballRb.position - this.lastPos; 

        ballRb.AddForce(motionVect.normalized * this.forceAmount);
    }
}
