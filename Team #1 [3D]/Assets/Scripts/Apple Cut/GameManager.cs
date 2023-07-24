using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int appleCount = 0;

    AudioSource audio;
    public AudioClip menuSFX;
    public AudioClip gameSFX;

    private void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
            audio = GetComponent<AudioSource>();

            if (currentScene == "Main Menu") {
                PlayMusic();
            }

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenu() {
        audio.Stop();
        audio.clip = menuSFX;
        audio.Play();
    }

    public void PlayMusic() {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level 1") {
            audio.Stop();
            audio.clip = gameSFX;
            audio.Play();
        }

        if (currentScene == "Main Menu") {
            PlayMenu();
        }
    }
}
