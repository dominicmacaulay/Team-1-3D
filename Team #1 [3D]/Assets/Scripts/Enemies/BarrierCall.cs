using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCall : MonoBehaviour
{
    public GameObject directionPanel;
    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        directionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("call enemy");
                //call enemy
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            directionPanel.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            directionPanel.SetActive(false);
            inRange = false;
        }
    }
}
