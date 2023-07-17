using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEntranceDoor : MonoBehaviour
{
    public Animator anim;
    public AudioSource audio;
    public AudioClip openSFX;

    public LabInitiationPanel panelScript;

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        //audio.PlayOneShot(openSFX);
        Debug.Log("open door");
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");
    }

    public void DoorClosed()
    {
        panelScript.DoorClosed();
    }
}
