using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPanelObject : MonoBehaviour
{
    public GameObject turretPanel;
    public GameObject HUD;
    public GameObject promptTrigger;

    // Start is called before the first frame update
    void Start()
    {
        turretPanel.SetActive(false);
    }

    public void AccessTurretPanel()
    {
        turretPanel.SetActive(true);
        HUD.SetActive(false);
        promptTrigger.SetActive(false);
    }
}
