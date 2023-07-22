using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEffects : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EndLife", time);
    }

    void EndLife()
    {
        Destroy(gameObject);
    }
}
