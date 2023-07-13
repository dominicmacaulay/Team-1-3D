using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DoorPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
