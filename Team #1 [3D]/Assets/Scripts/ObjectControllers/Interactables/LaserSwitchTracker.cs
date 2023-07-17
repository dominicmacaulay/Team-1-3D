using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchTracker : MonoBehaviour
{
    public bool switchOne = false;
    public bool switchTwo = false;

    public TriggerPrompts triggerScript;
    public GameObject promptTrigger;

    // Update is called once per frame
    void Update()
    {
        if (switchOne && switchTwo)
        {
            promptTrigger.SetActive(false);
            triggerScript.HidePanel();
        }
    }
}
