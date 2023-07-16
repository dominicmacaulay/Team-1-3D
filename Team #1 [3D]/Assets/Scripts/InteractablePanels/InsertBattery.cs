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

    private void Start()
    {
        if (gameObject.tag == "keypad battery")
        {
            keyCard.SetActive(false);
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

            if (gameObject.tag == "keypad battery")
            {
                prop.SetActive(false);
                keyCard.SetActive(true);
            }
        }
    }
}
