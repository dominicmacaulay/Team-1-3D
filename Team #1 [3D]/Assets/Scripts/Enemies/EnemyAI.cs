using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPointOne;
    public Vector3 walkPointTwo;
    public Vector3 currentWalkPoint;
    bool targetingPointOne = true;
    bool playerSeen = false;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        currentWalkPoint = walkPointOne;
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
        
        SearchWalkPoint();
        
        if (!playerSeen) agent.destination = currentWalkPoint;

        // Player in sight
        if (playerInSightRange)
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
        playerSeen = true;
        agent.destination = player.position;
    }

    private void AttackPlayer()
    {
        player.GetComponent<CollisionsManager>().InstantDeath();
        transform.LookAt(player);
        

        gameObject.SetActive(false);

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

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
