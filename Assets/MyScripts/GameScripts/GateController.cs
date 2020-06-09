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
    public Rigidbody ballRb;
    public bool ballExited;
    public bool gameReset;
    public float forceAmount;

    void Update()
    {
        if(ballExited)
        {
            if(Mathf.Round(transform.eulerAngles.z) != targetAngle)
            {
                transform.Rotate(closeDirection * speed);
            }
        }

        if(gameReset)
        {
            if(Mathf.Round(transform.eulerAngles.z) != initAngle)
            {
                transform.Rotate(openDirection * speed);
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            ballRb = c.gameObject.GetComponent<Rigidbody>();

            StartCoroutine(ShootBallCoroutine(1));
        }
    }   

    private IEnumerator ShootBallCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShootBall();

        yield return new WaitForSeconds(delay);
        ballExited = true;
    }

    private void ShootBall()
    {
        this.ballRb.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
    }
}
