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
    float lightsAlpha;
    bool doorOpen;

    public LabEntranceDoor doorScript;
    public SUPERCharacterAIO characterController;

    void Start()
    {
        pendingMessage.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            doorOpen = true;
            lightsAlpha = .5f;
            completedMessage.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            doorOpen = false;
            lightsAlpha = 1.0f;
            completedMessage.SetActive(true);
        }
    }

    void Update()
    {
        // lightsButton.color = new Color(lightsButton.color.r, lightsButton.color.g, lightsButton.color.b, lightsAlpha);
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
    }

    public void DoorClosed()
    {
        pendingMessage.SetActive(false);
        completedMessage.SetActive(true);
        lightsAlpha = 1;
        lightsReady = true;
    }
}
