using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBattery : MonoBehaviour
{
    public Animator anim;
    public bool isActivated;

    public void BatteryAnimation()
    {
        anim.SetTrigger("battery");
        isActivated = true;
    }
}
