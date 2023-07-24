using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public CollisionsManager playerScript;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public GameObject explosionSFX;

    //Patroling
    public Vector3 walkPointOne;
    public Vector3 walkPointTwo;
    public Vector3 currentWalkPoint;
    bool targetingPointOne = true;
    bool playerSeen = false;
    public float walkPointRange;

    AudioSource audio;
    public AudioClip idleTalk;
    public AudioClip chaseTalk;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator anim;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        InitialPath();
    }

    public void InitialPath() {
        audio.Stop();
        audio.clip = idleTalk;
        audio.Play();

        currentWalkPoint = walkPointOne;
        agent.Warp(walkPointTwo);
        playerSeen = false;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerSeen && !playerInAttackRange) Patroling();
        if (playerSeen && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        anim.SetBool("run", false);
        anim.SetBool("walk", true);
        SearchWalkPoint();
        agent.speed = 3f;
        
        if (!playerSeen) agent.destination = currentWalkPoint;

        // Player in sight
        if (playerInSightRange)
            audio.Stop();
            audio.clip = chaseTalk;
            audio.Play();

            playerSeen = true;
    }

    private void SearchWalkPoint()
    {
        Vector3 distanceToPointOne = transform.position - walkPointOne;
        Vector3 distanceToPointTwo = transform.position - walkPointTwo;

        if (targetingPointOne) {
            if (distanceToPointOne.magnitude < 1f) 
            {
                currentWalkPoint = walkPointTwo;
                targetingPointOne = false;
            } else {
                currentWalkPoint = walkPointOne;
                targetingPointOne = true;
            }
        } else {
            if (distanceToPointTwo.magnitude < 1f) {
                currentWalkPoint = walkPointOne;
                targetingPointOne = true;
            } else {
                currentWalkPoint = walkPointTwo;
                targetingPointOne = false;
            }
        }
    }

    private void ChasePlayer()
    {
        anim.SetBool("walk", false);
        anim.SetBool("run", true);
        playerSeen = true;
        agent.speed = 8f;
        agent.destination = player.position;
    }

    private void AttackPlayer()
    {
        StartCoroutine(KillPlayer());

        transform.LookAt(player);
        

        InitialPath();

        if (!alreadyAttacked)
        {
            ///Attack code here

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator KillPlayer()
    {
        Instantiate(explosionSFX, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);

        playerScript.InstantDeath();
    }
}
