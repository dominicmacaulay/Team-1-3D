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

    public Image acidPanel;
    public Image bulletPanel;
    public GameObject gameOverPanel;

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
            StartCoroutine(Death(acidPanel));
        }

        if (other.gameObject.tag == "lasers")
        {
            isAlive = false;            
        }

        if (other.gameObject.tag == "turret")
        {
            isBeingShot = true;
            StartCoroutine(BulletEffect());
            StartCoroutine(Death(bulletPanel));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "acid")
        {
            isTouchingAcid = false;
            StartCoroutine(AcidRegen());
            StopCoroutine(Death(acidPanel));
        }

        if (other.gameObject.tag == "turret")
        {
            isBeingShot = false;
            StartCoroutine(BulletRegen());
            StopCoroutine(Death(bulletPanel));
        }
    }

    IEnumerator AcidEffect()
    {
        while (isTouchingAcid == true && acidPanel.color.a < 1)
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
        while (isBeingShot == true && bulletPanel.color.a < 1)
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

    IEnumerator Death(Image panel)
    {
        yield return new WaitUntil(()=>panel.color.a > .4f);

        isAlive = false;
        yield return new WaitForSeconds(deathAnimation);

        gameOverPanel.SetActive(true);
        Destroy(gameObject);
        Debug.Log(isAlive);
    }
}
