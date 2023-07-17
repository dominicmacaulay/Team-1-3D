using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionsManager : MonoBehaviour
{
    public bool isAlive = true;
    public float panelTime;
    public float regenWait;
    public float panelIncrement;
    public float deathAnimation;

    bool isTouchingAcid = false;
    bool isBeingShot = false;

    public RawImage acidPanel;
    public RawImage bulletPanel;
    public GameObject gameOverPanel;
    public SUPERCharacterAIO characterController;
    public GameObject HUD;

    float acidAlpha = 0;
    float bulletAlpha = 0;

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
        }

        if (other.gameObject.tag == "lasers")
        {
            isAlive = false;
            StartCoroutine(Death());
        }

        if (other.gameObject.tag == "turret")
        {
            isBeingShot = true;
            StartCoroutine(BulletEffect());
            StartCoroutine(DeathCheck(bulletPanel));
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

        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        HUD.SetActive(false);
        characterController.PausePlayer();
        acidAlpha = 0;
        bulletAlpha = 0;
        yield return new WaitForSeconds(deathAnimation);
        gameOverPanel.SetActive(true);
        Debug.Log(isAlive);
    }

    public void InstantDeath() {
        isAlive = false;
        gameOverPanel.SetActive(true);

        StartCoroutine(Death());
    }
}
