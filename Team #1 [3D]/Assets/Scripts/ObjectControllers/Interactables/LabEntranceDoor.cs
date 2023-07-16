using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEntranceDoor : MonoBehaviour
{
    public Animator anim;
    public AudioSource audio;
    public AudioClip openSFX;

    public void OpenDoor()
    {
        //anim.SetTrigger("openDoor");
        //audio.PlayOneShot(openSFX);
        Debug.Log("open door");
    }

    public void CloseDoor()
    {
        Debug.Log("close Door");
    }
}
