using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float transitionTime;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            StartCoroutine(CreditsTransition());
        }

        if (SceneManager.GetActiveScene().name == "Win")
        {
            StartCoroutine(WinTransition());
        }
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickInstructions()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnClickSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnClickGoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator CreditsTransition()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator WinTransition()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Credits");
    }
}
