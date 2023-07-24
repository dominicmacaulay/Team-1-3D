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

    AudioSource audio;
    public AudioClip pickupSFX;
    public AudioClip placeSFX;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public void PickupBattery()
    {
        hasBattery = true;
        hudScript.Display01(hasBattery);
        PickupNoise();
    }

    public void PlaceBattery()
    {
        hasBattery = false;
        hudScript.Display01(hasBattery);
        PlaceNoise();
    }

    public void PickupKeyCard()
    {
        hasKeyCard = true;
        hudScript.Display02(hasKeyCard);
        PickupNoise();
    }

    public void PlaceKeyCard()
    {
        hasKeyCard = false;
        hudScript.Display02(hasKeyCard);
        PlaceNoise();
    }

    public void PickupEnergySource()
    {
        hasEnergySource = true;
        hudScript.Display01(hasEnergySource);
        PickupNoise();
    }

    public void PlaceEnergySource()
    {
        hasEnergySource = false;
        hudScript.Display01(hasEnergySource);
        PlaceNoise();
    }

    public void PickupPortalComponent()
    {
        hasPortalComponent = true;
        hudScript.Display02(hasPortalComponent);
        PickupNoise();
    }

    public void PlacePortalComponent()
    {
        hasPortalComponent = false;
        hudScript.Display02(hasPortalComponent);
        PlaceNoise();
    }

    void PickupNoise() {
        audio.PlayOneShot(pickupSFX, 1f);
    }

    void PlaceNoise() {
        audio.PlayOneShot(placeSFX, 1f);
    }
}
