using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollisions : MonoBehaviour
{
    public GameObject player;
    public Vector3 portalJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        player.transform.position = portalJump;
        yield return null;
    }
}
