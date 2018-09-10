using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointSolver : MonoBehaviour
{
	public WaypointGroup waypoints;
	public float tolerance = 0.5f;
	private NavMeshAgent agent;
	private Transform currentWaypoint = null;

	

	private bool isPatrolling = true;

	private int waypointIndex;
	
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		waypointIndex = waypoints.GetNearestWaypointIndex(transform);
		
	}

	private void SetWaypoint()
	{
		if (isPatrolling)
		{
			currentWaypoint = waypoints.GetWaypoint(waypointIndex);
			agent.SetDestination(currentWaypoint.position);
			
		}
	}

	private void Update()
	{
		SetWaypoint();
		
		if (currentWaypoint == null) return;
		
		
		if (agent.remainingDistance < tolerance)
	
		{
			waypointIndex = waypoints.IncrementIndex(waypointIndex);
			SetWaypoint();
		}
		
		
	}

	public void StopPatrolling()
	{
		isPatrolling = false;
		//agent.isStopped = true;

	}

	public void StartPatrolling()
	{
		isPatrolling = true;
		waypointIndex = waypoints.GetNearestWaypointIndex(transform);
		SetWaypoint();
	}
}
