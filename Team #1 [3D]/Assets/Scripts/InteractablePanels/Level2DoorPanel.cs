using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject HUD;

    public GameObject promptTrigger;
    public GameObject triggerPanel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        HUD.SetActive(false);
        promptTrigger.SetActive(false);
        triggerPanel.SetActive(false);
    }
}
