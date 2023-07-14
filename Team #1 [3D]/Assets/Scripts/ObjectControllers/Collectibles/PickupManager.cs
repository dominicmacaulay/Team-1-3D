using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public HUDPickups hudScript;

    public bool hasBattery;
    public bool hasKeyCard;
    public bool hasEnergySource;
    public bool hasPortalComponent;

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

    public void PickupEnergySource()
    {
        hasEnergySource = true;
        hudScript.Display01(hasEnergySource);
    }

    public void PlaceEnergySource()
    {
        hasEnergySource = false;
        hudScript.Display01(hasEnergySource);
    }

    public void PickupPortalComponent()
    {
        hasPortalComponent = true;
        hudScript.Display02(hasPortalComponent);
    }

    public void PlacePortalComponent()
    {
        hasPortalComponent = false;
        hudScript.Display02(hasPortalComponent);
    }
}
