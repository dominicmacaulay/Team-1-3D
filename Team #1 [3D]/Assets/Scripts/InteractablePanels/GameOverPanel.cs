using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject player;
    public Vector3 respawnPoint;
    public SUPERCharacterAIO characterController;
    public GameObject HUD;
    public CollisionsManager collisionsScript;
    public TMP_Text report;
    public string causeOfDeath;
    public Animator anim;

    private void Update()
    {
        report.text = "January 15th, 2031\r\n\r\nSecurity Officer: Dean Parker\r\n\r\nTerminated during aether testing malfunction. Cause of death found to be " + causeOfDeath + ".\r\n\r\nAccounted Casualty #35";
    }

    public void SetPosition()
    {
        player.transform.position = respawnPoint;
    }

    public void Respawn()
    {
        collisionsScript.isAlive = true;
        characterController.UnpausePlayer();
        HUD.SetActive(true);
    }
}
