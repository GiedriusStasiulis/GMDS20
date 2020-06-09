using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankShot_ChildTrigger : MonoBehaviour
{
    public Transform parentController;
    public int index;

    void Start()
    {
        parentController = this.transform.parent.parent;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")	
        {
            parentController.GetComponent<BankShotController>().ActivateButton(index);
            this.GetComponent<Collider>().enabled = false;
        }
    }       
}
