using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameOverPanel respawnScript;

    Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnScript.respawnPoint = respawnPoint;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
