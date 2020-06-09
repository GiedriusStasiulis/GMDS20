using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Transform respawnBallSpot;
    public Transform canvas;
    public GameObject ball;
    public PhysicMaterial physicMaterial;
    public int spawnCounter;    

    // Start is called before the first frame update
    void Start()
    {
        respawnBallSpot = GameObject.Find("RespawnBallSpot").transform;
        canvas = GameObject.Find("Canvas").transform;

        SpawnBall();
        spawnCounter += 1;
    }

    void SpawnBall()
    {
        ball = Instantiate(Resources.Load("MyModels/pinball", typeof(GameObject)), respawnBallSpot.position, respawnBallSpot.rotation) as GameObject;
        ball.name = "Ball";
        ball.tag = "Ball";
        Rigidbody ballRb = ball.AddComponent<Rigidbody>();
        ballRb.isKinematic = false;
        ballRb.useGravity = true;
        ballRb.mass = 1.5F;
        ballRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

        SphereCollider spColl = ball.AddComponent<SphereCollider>();
        spColl.material = physicMaterial;
    }  

    public void RespawnBall()
    {
        if(spawnCounter == 3)
        {
            //Game Over
            Debug.Log("Game over!");
            canvas.GetComponent<InGameMenu>().GameOver();
        }

        else
        {
            StartCoroutine(SpawnBallCoroutine(1));
            spawnCounter += 1;
        }
    }

    private IEnumerator SpawnBallCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnBall();
    }    
}
