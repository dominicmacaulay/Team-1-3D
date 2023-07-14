using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject HUD;
    bool rightLocker = false;

    public LockerPanel panelScript;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        if (gameObject.tag == "Jerr")
        {
            rightLocker = true;
        }
        panelScript.correctLocker = rightLocker;
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        HUD.SetActive(false);
    }
}
