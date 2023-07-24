using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public InsertBattery batteryScript;
    public LaserGrid laserGrid;
    public LaserSwitchTracker trackScript;

    Animator anim;

    AudioSource audio;
    public AudioClip switchSFX;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void FlipSwitch()
    {
        if (batteryScript.isActivated)
        {
            if (laserGrid.isDisabled == false)
            {
                audio.PlayOneShot(switchSFX, 1f);

                anim = GetComponent<Animator>();
                laserGrid.DisableGrid();
                Debug.Log("laser disabled");
                if (gameObject.tag == "switch01")
                {
                    anim.SetTrigger("Flip");
                    trackScript.switchOne = true;
                }
                if (gameObject.tag == "switch02")
                {
                    anim.SetTrigger("Flip");
                    trackScript.switchTwo = true;
                }
            }
        }
    }
}
