using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuicideAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject obstacle;
    bool proximity, player;
    public LayerMask whatIsObstacle;
    public LayerMask whatIsPlayer;
    public GameObject explosionSFX;
    public Transform explosionPoint;
    public CollisionsManager playerScript;


    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        proximity = Physics.CheckSphere(transform.position, .5f, whatIsObstacle);
        player = Physics.CheckSphere(transform.position, 5, whatIsPlayer);
        if (proximity)
        {
            StartCoroutine(Destroy());
            
        }
        
    }

    public void OnCall()
    {
        agent.destination = obstacle.transform.position;
    }

    IEnumerator Destroy()
    {
        if (player)
        {
            playerScript.InstantDeath();
        }
        Instantiate(explosionSFX, explosionPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);

        Destroy(gameObject);
        Destroy(obstacle);
    }
}
