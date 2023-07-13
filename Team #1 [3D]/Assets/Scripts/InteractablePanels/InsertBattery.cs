using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBattery : MonoBehaviour
{
    public PickupManager pickupScript;
    public Animator anim;
    public bool isActivated;

    public void BatteryAnimation()
    {
        if (pickupScript.hasBattery)
        {
            pickupScript.PlaceBattery();
            //anim.SetTrigger("battery");
            isActivated = true;
            Debug.Log("battery inserted");
        }
    }
}
