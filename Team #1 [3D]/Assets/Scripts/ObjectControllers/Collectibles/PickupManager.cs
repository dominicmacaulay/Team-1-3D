using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public HUDPickups hudScript;

    public bool hasBattery;
    public bool hasKeyCard;

    public void PickupBattery()
    {
        hasBattery = true;
        hudScript.Display01(hasBattery);
    }

    public void PlaceBattery()
    {
        hasBattery = false;
        hudScript.Display01(hasBattery);
    }

    public void PickupKeyCard()
    {
        hasKeyCard = true;
        hudScript.Display02(hasKeyCard);
    }

    public void PlaceKeyCard()
    {
        hasKeyCard = false;
        hudScript.Display02(hasKeyCard);
    }
}
