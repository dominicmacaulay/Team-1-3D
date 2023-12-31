using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CollisionsManager : MonoBehaviour
{
    public bool isAlive = true;
    public float panelTime;
    public float regenWait;
    public float panelIncrement;
    public float deathAnimation;

    bool isTouchingAcid = false;
    bool isBeingShot = false;

    // Use the PlayableDirector to start and stop cutscenes
    PlayableDirector timeline;

    public RawImage acidPanel;
    public RawImage bulletPanel;
    public GameOverPanel panelScript;
    public SUPERCharacterAIO characterController;
    public GameObject HUD;
    public GunTurret turretScript;

    float acidAlpha = 0;
    float bulletAlpha = 0;

    AudioSource audio;
    public AudioClip deathSFX;

    void Start() {
        GameObject camera = GameObject.Find("Camera");

        audio = GetComponent<AudioSource>();

        timeline = camera.GetComponent<PlayableDirector>();
        if (timeline != null) {
            Debug.Log("Timeline attached");
        }

        GameManager.instance.PlayMusic();
    }

    void Update()
    {
        acidPanel.color = new Color(acidPanel.color.r, acidPanel.color.g, acidPanel.color.b, acidAlpha);
        bulletPanel.color = new Color(bulletPanel.color.r, bulletPanel.color.g, bulletPanel.color.b, bulletAlpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "acid")
        {
            isTouchingAcid = true;
            StartCoroutine(AcidEffect());
            StartCoroutine(DeathCheck(acidPanel));
            panelScript.causeOfDeath = "prolonged exposure to contaminated toxic waste";
        }

        if (other.gameObject.tag == "lasers")
        {
            isAlive = false;
            StartCoroutine(Death());
            panelScript.causeOfDeath = "accidental or possibly forced contact with the laser defense mechanism";
        }

        if (other.gameObject.tag == "turret")
        {
            isBeingShot = true;
            StartCoroutine(BulletEffect());
            StartCoroutine(DeathCheck(bulletPanel));
            panelScript.causeOfDeath = "a malfunction with the security turret's targeting system";
        }
        if (other.gameObject.tag == "cutscene") {
            timeline.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "acid")
        {
            isTouchingAcid = false;
            StartCoroutine(AcidRegen());
            StopCoroutine(DeathCheck(acidPanel));
        }

        if (other.gameObject.tag == "turret")
        {
            isBeingShot = false;
            StartCoroutine(BulletRegen());
            StopCoroutine(DeathCheck(bulletPanel));
        }
    }

    IEnumerator AcidEffect()
    {
        while (isTouchingAcid == true && acidPanel.color.a < 1 & isAlive)
        {
            yield return new WaitForSeconds(panelTime);
            acidAlpha += panelIncrement;
        }
        yield break;
    }

    IEnumerator AcidRegen()
    {
        yield return new WaitForSeconds(regenWait);
        while (isTouchingAcid == false && acidPanel.color.a > 0)
        {
            yield return new WaitForSeconds(panelTime);
            acidAlpha -= panelIncrement;
        }
        yield break;
    }

    IEnumerator BulletEffect()
    {
        while (isBeingShot == true && bulletPanel.color.a < 1 && isAlive)
        {
            yield return new WaitForSeconds(panelTime);
            bulletAlpha += panelIncrement;
            
        }
        yield break;
    }

    IEnumerator BulletRegen()
    {
        yield return new WaitForSeconds(regenWait);
        while (isBeingShot == false && bulletPanel.color.a > 0)
        {
            yield return new WaitForSeconds(panelTime);
            bulletAlpha -= panelIncrement;
        }
        yield break;
    }

    IEnumerator DeathCheck(RawImage panel)
    {
        yield return new WaitUntil(()=>panel.color.a > .4f);

        isAlive = false;
        StopCoroutine(BulletEffect());
        StopCoroutine(AcidEffect());
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        if (deathSFX != null) {
            audio.PlayOneShot(deathSFX, 1f);
        }

        HUD.SetActive(false);
        characterController.PausePlayerForTransition();
        if (turretScript != null) {
            turretScript.inRange = false;
        }
        acidAlpha = 0;
        bulletAlpha = 0;
        yield return new WaitForSeconds(deathAnimation);
        panelScript.anim.SetTrigger("respawn");
    }

    public void InstantDeath() 
    {
        isAlive = false;
        panelScript.causeOfDeath = "a physical altercation with escaped test subjects";
        StartCoroutine(Death());
        Debug.Log("fuck");
    }
}
