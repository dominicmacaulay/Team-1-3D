using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    bool hasKeyCard; // temporary bool which will be accessed from the player scripts

    public Animator anim;
    public AudioSource audio;
    public AudioClip incorrectSFX;
    public AudioClip correctSFX;
    public GameObject labDoor;

    void Interaction()
    {
        if (GetComponent<InsertBattery>().isActivated)
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
        audio.PlayOneShot(correctSFX);
        labDoor.GetComponent<LabEntranceDoor>().OpenDoor();
    }

    void KeyCardRequired()
    {
        audio.PlayOneShot(incorrectSFX);
        anim.SetTrigger("incorrect");
    }
}
