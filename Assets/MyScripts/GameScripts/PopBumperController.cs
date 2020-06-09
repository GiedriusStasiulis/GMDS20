using UnityEngine;

public class PopBumperController : MonoBehaviour
{
    public float minPos = 0F;
    public float maxPos = 0.012F;
    public float speed;
    public float yPos;
    private Transform bumperFlange;
    private int bumperFlangeState;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")			
		bumperFlangeState = 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        bumperFlange = this.transform.GetChild(1);
    }    

    // Update is called once per frame
    void Update()
    {
        yPos = bumperFlange.localPosition.y;

        if (yPos < minPos)	
        {
            bumperFlangeState = 2;
        }

        if (yPos > maxPos && bumperFlangeState == 2)
        {
            bumperFlangeState = -1;
        }

        switch(bumperFlangeState)
        {
            case 1:
                //Go down
                bumperFlange.transform.Translate(Vector3.back * Time.deltaTime * speed);
                break;
        
            case 2:
                //Go up
                bumperFlange.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                break;
        }
    }
}
