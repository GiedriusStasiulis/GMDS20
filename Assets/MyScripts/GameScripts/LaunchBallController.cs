using System;
using System.Collections;
using UnityEngine;

public class LaunchBallController : MonoBehaviour
{
    public Transform plunger;
    public Animator animator;
    public bool ballReady;
    public Rigidbody ballRb;
    public float forceAmount;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            ballRb = c.gameObject.GetComponent<Rigidbody>();
            ballReady = true;
        }
    }    

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            ballReady = false;
        }
    }

    void Start()
    {
        animator = plunger.GetComponent<Animator>();
    }

    void Update()
    {          
        if(ballReady && ballRb != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {  
                StartCoroutine(AnimateSpringCoroutine(ShootBall));   
            }         
        }            
    }

    private IEnumerator AnimateSpringCoroutine(Action shootBall)
    {
        animator.Play("PlungerSpring");

        //Wait until current state is entered
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlungerSpring"))
        {
            yield return null;
        }

        //Wait until the current state is done playing
        while ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f)
        {
            animator.SetTrigger("stopAnimation");
            yield return null;
        }

        //Done playing
        shootBall();   
    }

    private void ShootBall()
    {
        this.ballRb.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
    }
}
