using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCollision : MonoBehaviour
{
    public GameObject trigger;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
        {
            trigger.SetActive(true);
            anim.SetTrigger("Flip");
        }
    }
}
