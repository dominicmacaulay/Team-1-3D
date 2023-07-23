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
    public Transform explosionPoint, respawnPoint;
    public CollisionsManager playerScript;
    public BarrierCall callScript;

    public Animator anim;


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
        //anim.SetBool("run", true);
    }

    IEnumerator Destroy()
    {
        Instantiate(explosionSFX, explosionPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        obstacle.SetActive(false);
        if (player)
        {
            agent.destination = respawnPoint.position;
            playerScript.InstantDeath();
            yield return new WaitForSeconds(1.5f);            
            gameObject.SetActive(true);
            obstacle.SetActive(true);
            callScript.exist = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
