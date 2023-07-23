using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCount : MonoBehaviour
{
    public GameObject switchPanel;

    // Start is called before the first frame update
    void Start()
    {
        switchPanel.SetActive(false);
        Invoke("SpawnPanel", 1.5f);
    }

    void SpawnPanel()
    {
        if (GameManager.instance.appleCount == 5)
        {
            switchPanel.SetActive(true);
        }
    }
}
