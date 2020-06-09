using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform launchBall;
    public Transform gate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(launchBall.GetComponent<LaunchBallController>().ballReady)
        {
            gate.GetComponent<GateController>().ballExited = false;
        }
    }
}
