using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollisions : MonoBehaviour
{
    public GameObject player;
    public Vector3 portalJump;
    public GameObject portalSFX;

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
        Instantiate(portalSFX, player.transform.position, Quaternion.identity);
        yield return null;
    }
}
