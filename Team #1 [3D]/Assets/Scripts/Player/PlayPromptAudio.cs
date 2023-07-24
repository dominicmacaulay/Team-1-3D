using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPromptAudio : MonoBehaviour
{
    AudioSource audio;
    public AudioClip clip;
    bool exist = true;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && exist)
        {
            audio.PlayOneShot(clip);
            exist = false;
        }
    }
}
