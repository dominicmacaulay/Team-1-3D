using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    public Animator anim;

    public Transform idlePoint;
    public Transform inactivePoint;
    public Transform player;
    public Transform turretHead;

    public Collider turretPath;

    bool isActive = true;
    bool inRange = false;

    void Update()
    {
        Look();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            //anim.SetBool("isShooting", true);
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            //anim.SetBool("isShooting", false);
            inRange = false;
        }
    }

    void Look()
    {
        if (isActive && inRange)
        {
            turretHead.LookAt(player);
        }
        else if (isActive)
        {
            turretHead.LookAt(idlePoint);
        }
        else if (isActive == false)
        {
            turretHead.LookAt(inactivePoint);
        }
    }

    public void DeactivateTurret()
    {
        isActive = false;
        turretPath.enabled = false;
        //anim.SetBool("isInactive", true);
    }
}
