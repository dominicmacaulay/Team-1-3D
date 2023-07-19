using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPickups : MonoBehaviour
{
    public GameObject display01_color, display01_default;
    public GameObject display02_color, display02_default;

    void Start()
    {
        display01_color.SetActive(false);
        display02_color.SetActive(false);
    }

    public void Display01(bool active)
    {
        display01_color.SetActive(active);
        display01_default.SetActive(!active);
    }

    public void Display02(bool active)
    {
        display02_color.SetActive(active);
        display02_default.SetActive(!active);
    }
}
