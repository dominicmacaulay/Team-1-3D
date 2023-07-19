using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    public Transform idlePoint, turretHead, inactivePoint, player, muzzlePoint;

    public GameObject SFX;
    public Collider turretPath;

    bool isActive = true;
    public bool inRange = false;

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
            StartCoroutine(SpawnSFX());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            //anim.SetBool("isShooting", false);
            inRange = false;
            StopCoroutine(SpawnSFX());
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

    public IEnumerator SpawnSFX()
    {
        while (inRange)
        {
            Instantiate(SFX, muzzlePoint.position, Quaternion.Euler(new Vector3(0, -90, 0)));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
