using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollisions : MonoBehaviour
{
    public GameObject player;
    public Vector3 portalJump;
    public GameObject portalSFX;

    AudioSource audio;
    public AudioClip teleportSFX;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
        {
            StartCoroutine(Teleport());
            Destroy(other.gameObject);
        }
    }

    IEnumerator Teleport()
    {
        player.transform.position = portalJump;
        Instantiate(portalSFX, player.transform.position, Quaternion.identity);
        audio.PlayOneShot(teleportSFX, 1f);
        yield return null;
    }
}
