using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patrol,
    Chase,
    Dead
}

public class Enemy : MonoBehaviour
{
    private EnemyState state = EnemyState.Patrol;
    private NavMeshAgent agent;
    private WaypointSolver wpSolver;
    private GameObject player;
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = FindObjectOfType<GameObject>();
        animator.SetFloat("Walk", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wpSolver.StopPatrolling();
            state = EnemyState.Chase;
            animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == EnemyState.Chase)
            {
                // state = EnemyState.Patrol;
                // wpSolver.StartPatrolling();
                animator.SetBool("Attack", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
        if (state == EnemyState.Chase)
        {
            agent.SetDestination(player.transform.position);
           
        }
    }
}