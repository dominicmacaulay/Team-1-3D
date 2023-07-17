using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public PickupManager pickupScript;
    public GameObject batteryPanel;
    public Animator anim;
    public AudioSource audio;
    public AudioClip incorrectSFX;
    public AudioClip correctSFX;
    public GameObject labDoor;

    public GameObject promptTrigger;
    public GameObject triggerPanel;
    public TMP_Text triggerText;

    public void Interaction()
    {
        if (batteryPanel.GetComponent<InsertBattery>().isActivated)
        {
            if (pickupScript.hasKeyCard) //replace with player component
            {
                SwipeKeyCard();
            }
            else
            {
                KeyCardRequired();
            }
        }
    }

    void SwipeKeyCard()
    {
        pickupScript.PlaceKeyCard();
        Debug.Log("swiped");
        //audio.PlayOneShot(correctSFX);
        //anim.SetTrigger("correct");
        labDoor.GetComponent<LabEntranceDoor>().OpenDoor();
        promptTrigger.SetActive(false);
        triggerPanel.SetActive(false);
    }

    void KeyCardRequired()
    {
        Debug.Log("required");
        triggerText.text = "Administrator Key Card Required";
        //audio.PlayOneShot(incorrectSFX);
        //anim.SetTrigger("incorrect");
        Invoke("ResetText", 1.5f);
    }

    void ResetText()
    {
        triggerText.text = "Press E to swipe Key Card";
    }
}
