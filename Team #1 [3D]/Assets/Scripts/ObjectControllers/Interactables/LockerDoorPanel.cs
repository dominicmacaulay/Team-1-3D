using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject HUD;
    public GameObject promptTrigger;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        HUD.SetActive(false);
        promptTrigger.SetActive(false);
    }
}
