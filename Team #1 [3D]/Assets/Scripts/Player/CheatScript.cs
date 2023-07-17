using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatScript : MonoBehaviour
{
    public PickupManager pickupScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            pickupScript.PickupBattery();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            pickupScript.PickupKeyCard();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            pickupScript.PickupEnergySource();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pickupScript.PickupPortalComponent();
        }
    }
}
