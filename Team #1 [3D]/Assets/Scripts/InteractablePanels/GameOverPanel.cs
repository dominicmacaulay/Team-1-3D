using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject player;
    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickRestartButton()
    {
        Instantiate(player, respawnPoint, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
