using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerPrompts : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text panelText;

    public string promptText;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelText.text = promptText;
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panel.SetActive(false);
        }
    }
}
