using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject HUD;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        HUD.SetActive(false);
    }
}
