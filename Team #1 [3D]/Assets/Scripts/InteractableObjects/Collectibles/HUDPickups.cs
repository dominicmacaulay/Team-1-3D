using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPickups : MonoBehaviour
{
    public GameObject display01;
    public GameObject display02;

    void Start()
    {
        display01.SetActive(false);
        display02.SetActive(false);
    }

    public void Display01(bool active)
    {
        display01.SetActive(active);
    }

    public void Display02(bool active)
    {
        display02.SetActive(active);
    }
}
