using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{    
    public Transform gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera").transform;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")			
		Destroy(c.gameObject);

        gameManager.GetComponent<GameManager>().RespawnBall();
    }
}
