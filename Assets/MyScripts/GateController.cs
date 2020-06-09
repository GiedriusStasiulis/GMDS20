using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public float speed;
    public float initAngle;
    public float targetAngle;
    public Vector3 closeDirection;
    public Vector3 openDirection;
    
    public bool ballExited;

    void Update()
    {
        if(ballExited)
        {
            if(Mathf.Round(transform.eulerAngles.z) != targetAngle)
            {
                transform.Rotate(closeDirection * speed);
            }
        }

        else
        {
            if(Mathf.Round(transform.eulerAngles.z) != initAngle)
            {
                transform.Rotate(openDirection * speed);
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            Debug.Log("Ball exited!");      
            ballExited = true;     
        }
    }   
}
