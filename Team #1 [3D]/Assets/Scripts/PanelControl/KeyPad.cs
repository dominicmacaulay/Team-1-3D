using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public bool hasKeyCard; // temporary bool which will be accessed from the player scripts
    public GameObject batteryPanel;
    public Animator anim;
    public AudioSource audio;
    public AudioClip incorrectSFX;
    public AudioClip correctSFX;
    public GameObject labDoor;

    public void Interaction()
    {
        if (batteryPanel.GetComponent<InsertBattery>().isActivated)
        {
            if (hasKeyCard) //replace with player component
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
        Debug.Log("swiped");
        //audio.PlayOneShot(correctSFX);
        //anim.SetTrigger("correct");
        labDoor.GetComponent<LabEntranceDoor>().OpenDoor();
    }

    void KeyCardRequired()
    {
        Debug.Log("required");
        //audio.PlayOneShot(incorrectSFX);
        //anim.SetTrigger("incorrect");
    }
}
