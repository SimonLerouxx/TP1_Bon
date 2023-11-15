using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : TaskBT
{
    private Vector3[] Destinations { get; set; }
    private NavMeshAgent Agent { get; set; }
    private int CurrentDestinationID { get; set; }

    public Patrol(Vector3[] destinations, NavMeshAgent agent)
    {
        Destinations = destinations;
        Agent = agent;
    }

    public override TaskState Execute()
    {

        Vector3 currentDestination = Destinations[CurrentDestinationID];
        Agent.destination = currentDestination;
        
        if (Vector3.Distance(currentDestination, Agent.transform.position) < Agent.stoppingDistance)
        {
            CurrentDestinationID = (CurrentDestinationID + 1) % Destinations.Length;
            return TaskState.Success;
        }
        return TaskState.Running;
    }
}
