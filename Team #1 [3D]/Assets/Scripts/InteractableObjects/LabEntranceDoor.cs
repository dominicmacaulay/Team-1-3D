using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEntranceDoor : MonoBehaviour
{
    public Animator anim;

    public void OpenDoor()
    {
        anim.SetTrigger("openDoor");
    }
}
