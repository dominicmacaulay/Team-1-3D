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

    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;

    bool unlockable = false;
    public bool correctLocker;

    public LockerDoor doorScript;
    public GameObject HUD;
    public SUPERCharacterAIO characterController;

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
    }

    public void OnClickEnter()
    {
        if (num1 == 3 && num2 == 8 && num3 == 2 && num4 == 5 && correctLocker)
        {
            doorScript.OpenDoor();
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
    }
}
