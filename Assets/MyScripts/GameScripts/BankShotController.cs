using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankShotController : MonoBehaviour
{
    public float speed;
    public Vector3 initLocalZPos;
    public Vector3 targetLocalZPos;

    public List<GameObject> buttons = new List<GameObject>();
    public List<GameObject> triggerObj = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    public List<Collider> triggers = new List<Collider>();
    
    public bool firstBtnActivated;
    public bool secondBtnActivated;
    public bool thirdBtnActivated;
    public bool resetBankShot;

    // Start is called before the first frame update
    void Start()
    {
        this.initLocalZPos = new Vector3(this.transform.localPosition.x,
                                            this.transform.localPosition.y,
                                            this.transform.localPosition.z);

        this.targetLocalZPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, -0.0153F);

        this.triggers = GetTriggers(triggerObj);
        this.SetMaterialInitColor(materials);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstBtnActivated)
        {
            materials[0].SetColor("_Color", Color.green);
            materials[0].SetColor("_EmissionColor", Color.green * 10000);
        }

        if(secondBtnActivated)
        {
            materials[1].SetColor("_Color", Color.green);
            materials[1].SetColor("_EmissionColor", Color.green * 10000);
        }

        if(thirdBtnActivated)
        {
            materials[2].SetColor("_Color", Color.green);
            materials[2].SetColor("_EmissionColor", Color.green * 10000);
        }
    }

    public void FixedUpdate()
    {
        if(firstBtnActivated && secondBtnActivated && thirdBtnActivated)
        {           
            MoveBankShotDown();   
        }
    }

    //For future implementation
    /*private IEnumerator MovementCoroutine(float shortWaitTime, float longWaitTime, Action secondAction, Action lastAction)
    {
        MoveBankShotDown();    
        yield return new WaitForSeconds(shortWaitTime);

        firstBtnActivated = false;
        secondBtnActivated = false;
        thirdBtnActivated = false;

        this.SetMaterialInitColor(materials);

        yield return new WaitForSeconds(longWaitTime);
        secondAction();        

        yield return new WaitForSeconds(shortWaitTime);
        lastAction();
    }*/

    public void MoveBankShotDown()
    {        
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, targetLocalZPos, this.speed * Time.deltaTime);
    }

    public void MoveBankShotUp()
    {        
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, initLocalZPos, this.speed * Time.deltaTime);
    }

    List<Collider> GetTriggers(List<GameObject> triggerObjs)
    {
        List<Collider> triggs = new List<Collider>();

        for(int i = 0; i < triggerObjs.Count; i++)
        {
            triggs.Add(triggerObjs[i].GetComponent<Collider>());
        }

        return triggs;
    }

    void SetMaterialInitColor(List<Material> mats)
    {
        for(int i = 0; i < mats.Count; i++)
        {
            mats[i].SetColor("_Color", Color.red);
            mats[i].SetColor("_EmissionColor", Color.red * 1000);
        }
    }

    void DisableTriggers()
    {
        for(int i = 0; i < triggers.Count; i++)
        {
            triggers[i].enabled = false;
        }
    }

    void EnableTriggers()
    {
        for(int i = 0; i < triggers.Count; i++)
        {
            triggers[i].enabled = true;
        }
    }

    public void ActivateButton(int index)
    {
        switch(index)
        {
            case 1: 
                firstBtnActivated = true;
                break;

            case 2:
                secondBtnActivated = true;
                break;

            case 3:
                thirdBtnActivated = true;
                break;
        }        
    }
}
