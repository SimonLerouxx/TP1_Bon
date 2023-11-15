using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : TaskBT
{
    private NavMeshAgent Agent { get; set; }

    private GameObject Player { get; set; }

    const float maxTimeChasing = 10f;
    float timeSinceChasing = 0;

    public Chase(NavMeshAgent agent, GameObject player)
    {

        Agent = agent;
        Player = player;
    }

    public override TaskState Execute()
    {
        timeSinceChasing+= Time.deltaTime;

        Agent.destination = Player.transform.position;
        

        if (timeSinceChasing>= maxTimeChasing)
        {
            timeSinceChasing=0;
            return TaskState.Success;
        }
        return TaskState.Running;
    }
}