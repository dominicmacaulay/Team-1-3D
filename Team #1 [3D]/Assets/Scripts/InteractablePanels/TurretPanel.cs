using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics.Tracing;
using SUPERCharacter;

public class TurretPanel : MonoBehaviour
{
    public TMP_Text nameSpace;
    int index = 0;
    List<string> nameText = new List<string>()
    {
        "JU5TAB0AT.68",
        "DEACTIVATE.45",
        "NEBULUS.32",
        "REDACTED.57",
        "ADMIRAL.72",
    };
    int lockNumber = -18;
    public GameObject dial;
    int powerLevel;
    bool ready = false;

    public GameObject turret;
    public GameObject HUD;
    public GameObject promptTrigger;

    AudioSource audio;
    public AudioClip interactSFX;
    public AudioClip deactivateSFX;

    bool triggerStay = true;

    public SUPERCharacterAIO characterController;

    void Start()
    {
        UpdateButtonColor();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        nameSpace.text = nameText[index].ToString();

        dial.transform.eulerAngles = new Vector3(0, 0, lockNumber);
    }

    public void OnClickLeftNameButton()
    {
        if (index > 0)
        {
            index -= 1;
        }
        UpdateButtonColor();
        InteractNoise();
    }

    public void OnClickRightNameButton()
    {
        if (index < 4)
        {
            index += 1;
        }
        UpdateButtonColor();
        InteractNoise();
    }

    public void OnClickDialButton()
    {
        lockNumber -= 36;
        if (lockNumber < -342)
        {
            lockNumber = -18;
        }
        UpdateButtonColor();
        InteractNoise();
    }

    public void SliderValue(Slider slider)
    {
        powerLevel = (int)slider.value;
        UpdateButtonColor();
        InteractNoise();
    }

    public void OnClickDeactivateButton()
    {
        if (ready)
        {
            turret.GetComponent<GunTurret>().DeactivateTurret();
            triggerStay = false;
            audio.PlayOneShot(deactivateSFX, 1f);
        }
    }

    public void OnClickExitButton()
    {
        gameObject.SetActive(false);
        characterController.UnpausePlayer();
        HUD.SetActive(true);
        if (triggerStay)
        {
            promptTrigger.SetActive(true);
        }
        InteractNoise();
    }

    void UpdateButtonColor()
    {
        if (index == 2 && lockNumber == -234 && powerLevel == 3)
        {
            GetComponent<ButtonColorChange>().ChangeButtonColor(Color.green);
            ready = true;
        }
        else
        {
            GetComponent<ButtonColorChange>().ChangeButtonColor(Color.red);
        }
    }

    void InteractNoise() {
        audio.PlayOneShot(interactSFX, 1f);
    }
}
