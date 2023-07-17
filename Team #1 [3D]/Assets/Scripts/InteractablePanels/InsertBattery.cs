using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBattery : MonoBehaviour
{
    public PickupManager pickupScript;
    public Animator anim;
    public bool isActivated;

    public GameObject prop;
    public GameObject keyCard;
    public GameObject keyPadTrigger;
    public GameObject promptTrigger;
    public GameObject triggerPanel;
    public GameObject switchTrigger;

    private void Start()
    {
        if (gameObject.tag == "keypad battery")
        {
            keyCard.SetActive(false);
            keyPadTrigger.SetActive(false);
        }
        else
        {
            switchTrigger.SetActive(false);
        }
    }

    public void BatteryAnimation()
    {
        if (pickupScript.hasBattery)
        {
            pickupScript.PlaceBattery();
            //anim.SetTrigger("battery");
            isActivated = true;
            Debug.Log("battery inserted");
            promptTrigger.SetActive(false);
            triggerPanel.SetActive(false);

            if (gameObject.tag == "keypad battery")
            {
                prop.SetActive(false);
                keyCard.SetActive(true);
                keyPadTrigger.SetActive(true);
            }
            else
            {
                switchTrigger.SetActive(true);
            }
        }
    }
}
