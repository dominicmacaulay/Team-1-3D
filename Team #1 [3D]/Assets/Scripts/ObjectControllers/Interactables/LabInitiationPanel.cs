using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using SUPERCharacter;

public class LabInitiationPanel : MonoBehaviour
{
    public GameObject HUD;
    public GameObject pendingMessage;
    public GameObject completedMessage;
    public Image lightsButton;
    bool lightsReady = false;
    float lightsAlpha = .5f;
    bool doorOpen = true;

    public LabEntranceDoor doorScript;
    public SUPERCharacterAIO characterController;
    public GameObject promptTrigger;

    void Start()
    {
        pendingMessage.SetActive(false);
        completedMessage.SetActive(false);
    }

    void Update()
    {
        lightsButton.color = new Color(lightsButton.color.r, lightsButton.color.g, lightsButton.color.b, lightsAlpha);
    }
    public void OnClickCloseButton()
    {
        if (doorOpen)
        {
            doorOpen = false;
            doorScript.CloseDoor();
            pendingMessage.SetActive(true);
        }
    }

    public void OnClickLightsButton()
    {
        if (lightsReady)
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    public void OnClickExitButton()
    {
        gameObject.SetActive(false);
        characterController.UnpausePlayer();
        HUD.SetActive(true);
        promptTrigger.SetActive(true);
    }

    public void DoorClosed()
    {
        pendingMessage.SetActive(false);
        completedMessage.SetActive(true);
        lightsAlpha = 1;
        lightsReady = true;
    }
}
