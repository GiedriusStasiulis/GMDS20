using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform launchBall;
    public Transform gate;

    // Start is called before the first frame update
    void Start()
    {
        launchBall.GetComponent<LaunchBallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
