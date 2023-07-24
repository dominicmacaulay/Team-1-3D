using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoor : MonoBehaviour
{
    public Animator anim;
    
    AudioSource audio;
    public AudioClip openSFX;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("open");
        audio.PlayOneShot(openSFX);
        Debug.Log("open door");
    }
}
