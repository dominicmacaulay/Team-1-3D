using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    public Transform idlePoint, turretHead, inactivePoint, player, muzzlePoint;

    public GameObject SFX;
    public Collider turretPath;
    public Animator anim;

    AudioSource audio;

    bool isActive = true;
    public bool inRange = false;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            //anim.SetBool("isShooting", true);
            inRange = true;
            StartCoroutine(SpawnSFX());
            StartCoroutine(SpawnGunNoise());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isActive)
        {
            //anim.SetBool("isShooting", false);
            inRange = false;
            StopCoroutine(SpawnSFX());
            StopCoroutine(SpawnGunNoise());
            audio.Stop();
        }
    }

    public void DeactivateTurret()
    {
        isActive = false;
        turretPath.enabled = false;
        //anim.SetBool("isInactive", true);
        Invoke("Animation", 2);
    }

    void Animation()
    {
        anim.SetTrigger("Inactive");
    }

    public IEnumerator SpawnGunNoise() {
        while (inRange) {
            audio.Play();
            yield return new WaitForSeconds(9f);
        }
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
