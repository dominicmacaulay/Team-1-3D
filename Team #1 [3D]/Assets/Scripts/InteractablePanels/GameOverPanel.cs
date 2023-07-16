using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject player;
    public Vector3 respawnPoint;
    public SUPERCharacterAIO characterController;
    public GameObject HUD;
    public CollisionsManager collisionsScript;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClickRestartButton()
    {
        collisionsScript.isAlive = true;
        player.transform.position = respawnPoint;
        gameObject.SetActive(false);
        characterController.UnpausePlayer();
        HUD.SetActive(true);
    }
}
