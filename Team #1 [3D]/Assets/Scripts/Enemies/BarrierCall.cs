using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCall : MonoBehaviour
{
    public GameObject directionPanel;
    bool inRange = false;
    public bool exist = true;

    public SuicideAI enemyScript;

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
                exist = false;
                directionPanel.SetActive(false);
                enemyScript.OnCall();
                //call enemy
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && exist)
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
