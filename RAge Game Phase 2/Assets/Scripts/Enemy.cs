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
    public GameObject player;
    public Animator animator;
    public Enemycontoller enemy;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = GameObject.FindGameObjectWithTag("Player");
        state = EnemyState.Chase;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            state = EnemyState.Chase;
            animator.SetBool("Attack", true);
            wpSolver.StopPatrolling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == EnemyState.Chase)
            {
                 //state = EnemyState.Patrol;
                 //wpSolver.StartPatrolling();
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