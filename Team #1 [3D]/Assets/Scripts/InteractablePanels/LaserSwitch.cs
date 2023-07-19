using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public InsertBattery batteryScript;
    public LaserGrid laserGrid;
    public LaserSwitchTracker trackScript;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FlipSwitch()
    {
        if (batteryScript.isActivated)
        {
            if (laserGrid.isDisabled == false)
            {
                anim.SetTrigger("flip");
                laserGrid.DisableGrid();
                Debug.Log("laser disabled");
                if (gameObject.tag == "switch01")
                {
                    trackScript.switchOne = true;
                }
                if (gameObject.tag == "switch02")
                {
                    trackScript.switchTwo = true;
                }
            }
        }
    }
}
