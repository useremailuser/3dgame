using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Important Stats")]
    public float sightRange;
    public float walkPointRange;
    public bool alwaysChasing;
    public bool returnsToStart;

    [Header("Nerd Stuff")]
    public bool playerInSightRange;
    public NavMeshAgent agent;
    public Transform player;
    public Animator anim;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;

    Vector3 startingPos;

    [Header("SFX")]
    public AudioClip spottedSFX;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        if (returnsToStart) 
        {
            walkPointRange = 0f;
        }

        startingPos = gameObject.transform.position;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        if (playerInSightRange || alwaysChasing) ChasePlayer();


    }

    private void Patroling()
    {
        anim.Play("Enemy Idle");

        if (!returnsToStart)
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }
        else
        {
            agent.SetDestination(startingPos);
        }
        
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        anim.Play("Enemy Chasing");
        agent.SetDestination(player.position);
        if(!alwaysChasing)
        {
            AudioManager.audioInstance.sfxAudio.PlayOneShot(spottedSFX);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }

}
