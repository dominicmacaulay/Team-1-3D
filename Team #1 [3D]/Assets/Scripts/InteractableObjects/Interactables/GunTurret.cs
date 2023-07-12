using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    public Animator anim;

    public Transform player;
    public Transform turretHead;
    float distance;
    public float maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        //anim.SetBool("isShooting", true);
        Debug.Log("shooting");
    }

    private void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        //if (distance <= maxDistance )
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            turretHead.LookAt(player);
        }
    }

    public void DeactivateTurret()
    {
        //anim.SetBool("isShooting", false);
        Debug.Log("not shooting");
    }
}
