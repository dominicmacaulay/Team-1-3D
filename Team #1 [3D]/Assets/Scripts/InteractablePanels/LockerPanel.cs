using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SUPERCharacter;

public class LockerPanel : MonoBehaviour
{
    public TMP_Text num1Text;
    public TMP_Text num2Text;
    public TMP_Text num3Text;
    public TMP_Text num4Text;

    AudioSource audio;
    public AudioClip interactSFX;
    public AudioClip unlockSFX;

    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;

    public LockerDoor doorScript;
    public GameObject HUD;
    public SUPERCharacterAIO characterController;
    public GameObject promptTrigger;
    public GameObject pickupTrigger;

    bool triggerStay = true;

    private void Start()
    {
        pickupTrigger.SetActive(false);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        num3Text.text = num3.ToString();
        num4Text.text = num4.ToString();
    }

    public void UpButtonOne()
    {
        if (num1 < 9)
        {
            num1++;
        }
        else
        {
            num1 = 0;
        }

        audio.PlayOneShot(interactSFX, 1f);
    }
    public void UpButtonTwo()
    {
        if (num2 < 9)
        {
            num2++;
        }
        else
        {
            num2 = 0;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }
    public void UpButtonThree()
    {
        if (num3 < 9)
        {
            num3++;
        }
        else
        {
            num3 = 0;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }
    public void UpButtonFour()
    {
        if (num4 < 9)
        {
            num4++;
        }
        else
        {
            num4 = 0;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }

    public void DownButtonOne()
    {
        if (num1 > 0)
        {
            num1--;
        }
        else
        {
            num1 = 9;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }
    public void DownButtonTwo()
    {
        if (num2 > 0)
        {
            num2--;
        }
        else
        {
            num2 = 9;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }
    public void DownButtonThree()
    {
        if (num3 > 0)
        {
            num3--;
        }
        else
        {
            num3 = 9;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }
    public void DownButtonFour()
    {
        if (num4 > 0)
        {
            num4--;
        }
        else
        {
            num4 = 9;
        }
        audio.PlayOneShot(interactSFX, 1f);
    }

    public void OnClickEnter()
    {
        if (num1 == 3 && num2 == 8 && num3 == 2 && num4 == 5)
        {           
            triggerStay = false;
            audio.PlayOneShot(unlockSFX, 1f);
            // unlock animation
        }
        else
        {
            // lock shake animation
        }
    }

    public void OnClickExit()
    {
        gameObject.SetActive(false);
        characterController.UnpausePlayer();
        HUD.SetActive(true);
        if (triggerStay)
        {
            promptTrigger.SetActive(true);
        }
        else
        {
            doorScript.OpenDoor();
            pickupTrigger.SetActive(true);
        }
    }
}
