using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuicideAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject obstacle;
    bool proximity, player, isAble;
    public LayerMask whatIsObstacle;
    public LayerMask whatIsPlayer;
    public GameObject explosionSFX;
    public Transform explosionPoint, respawnPoint, batteryPoint;
    public CollisionsManager playerScript;
    public BarrierCall callScript;

    public Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        isAble = true;
    }

    // Update is called once per frame
    void Update()
    {
        proximity = Physics.CheckSphere(transform.position, .5f, whatIsObstacle);
        player = Physics.CheckSphere(transform.position, 5, whatIsPlayer);
        if (proximity && isAble)
        {
            StartCoroutine(Destroy());            
        }
        
    }

    public void OnCall()
    {
        agent.destination = obstacle.transform.position;
        anim.SetBool("run", true);
    }

    IEnumerator Destroy()
    {
        isAble = false;
        Instantiate(explosionSFX, explosionPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        obstacle.SetActive(false);
        if (player)
        {
            agent.Warp(respawnPoint.position);
            transform.LookAt(batteryPoint.position);
            playerScript.InstantDeath();            
            gameObject.SetActive(true);
            obstacle.SetActive(true);
            callScript.exist = true;
            anim.SetBool("run", false);
            isAble = true;
        }
        else
        {
            Debug.Log("bruv");
            gameObject.SetActive(false);
        }
    }
}
