using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStretchEnemySpawn : MonoBehaviour
{
    public PickupManager pickupScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (pickupScript.hasKeyCard)
            {
                Debug.Log("spawn enemy");
            }
        }
    }
}
