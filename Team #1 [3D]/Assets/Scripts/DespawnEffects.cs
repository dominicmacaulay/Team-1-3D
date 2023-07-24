using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEffects : MonoBehaviour
{
    public float time;
    AudioSource audio;
    public AudioClip explosionSFX;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Invoke("EndLife", time);
        audio.PlayOneShot(explosionSFX, 1f);
    }

    void EndLife()
    {
        Destroy(gameObject);
    }
}
