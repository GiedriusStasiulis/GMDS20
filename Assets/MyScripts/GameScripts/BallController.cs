using UnityEngine;

public class BallController : MonoBehaviour
{
    public PhysicMaterial physicMaterial;
    public GameObject ball;
    public Transform respawnBallSpot;
    public float forceAmount;

    // Start is called before the first frame update
    void Start()
    {
        respawnBallSpot = GameObject.Find("RespawnBallSpot").transform;
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        //For debugging/testing
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBall();
        }

        /*if (Input.GetKeyUp(KeyCode.E))
        {      
            if(ball != null)
            {
                ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
            }            
        }*/
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
}
