using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunBuild : MonoBehaviour
{
    public PickupManager pickupScript;
    public GameObject message;
    public GameObject portalGun;

    bool hasPower;
    bool hasTeleport;

    // Start is called before the first frame update
    void Start()
    {
        portalGun.SetActive(false);
        DeactivateMessage();
    }

    // Update is called once per frame
    void Update()
    {
        hasPower = pickupScript.hasEnergySource;
        hasTeleport = pickupScript.hasPortalComponent;
    }

    public void BuildGun()
    {
        if (hasPower && hasTeleport)
        {
            portalGun.SetActive(true);
        }
        else
        {
            message.SetActive(true);
            Invoke("DeactivateMessage", 2.5f);
        }
    }

    void DeactivateMessage()
    {
        message.SetActive(false);
    }
}
