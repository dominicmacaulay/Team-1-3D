using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public InsertBattery batteryScript;
    public LaserGrid laserGrid;

    public void FlipSwitch()
    {
        if (batteryScript.isActivated)
        {
            if (laserGrid.isDisabled == false)
            {
                laserGrid.DisableGrid();
                Debug.Log("laser disabled");
            }
        }
    }
}
