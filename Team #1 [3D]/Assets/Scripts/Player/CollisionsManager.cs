using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsManager : MonoBehaviour
{
    public bool isAlive = true;
    public float gracePeriod;
    public float panelTime;

    bool isTouchingAcid = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "acid")
        {
            isTouchingAcid = true;
            StartCoroutine(AcidEffect());
            StartCoroutine(Death());
        }

        if (other.gameObject.tag == "lasers")
        {
            isAlive = false;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "acid")
        {
            isTouchingAcid = false;
            StartCoroutine(AcidRegen());
            StopCoroutine(Death());
        }
    }

    IEnumerator AcidEffect()
    {
        while (isTouchingAcid == true)
        {
            yield return new WaitForSeconds(panelTime);
            Debug.Log("acid");
            //panel stuff
        }
        yield break;
    }

    IEnumerator AcidRegen()
    {
        while (isTouchingAcid == false)
        {
            yield return new WaitForSeconds(panelTime);
            //panel stuff
            Debug.Log("regen");
        }
        yield break;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(gracePeriod);

        isAlive = false;
        Debug.Log(isAlive);
    }
}
