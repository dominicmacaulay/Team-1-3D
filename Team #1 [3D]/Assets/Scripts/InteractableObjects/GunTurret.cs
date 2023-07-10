using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isShooting", true);
    }

    public void DeactivateTurret()
    {
        anim.SetBool("isShooting", false);
    }
}
