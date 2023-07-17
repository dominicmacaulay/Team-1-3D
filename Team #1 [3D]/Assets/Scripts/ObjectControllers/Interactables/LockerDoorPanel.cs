using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject HUD;
    public GameObject promptTrigger;
    public GameObject triggerPanel;
    public GameObject pickupTrigger;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        pickupTrigger.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        HUD.SetActive(false);
        promptTrigger.SetActive(false);
        triggerPanel.SetActive(false);
    }
}
