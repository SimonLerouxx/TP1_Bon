using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourTree : MonoBehaviour
{
    [SerializeField]
    Transform[] patrolDestinations;
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    GameObject Player;

    private Node rootBT;

    private void Awake()
    {
        Vector3[] destinations = patrolDestinations.Select(t => t.position).ToArray();
        TaskBT[] tasksPatrol = new TaskBT[]
        {
            new Patrol(destinations, agent)
        };
        TaskBT[] tasksWait = new TaskBT[]
        {
            new Wait(2)
        };
        TaskBT[] taskChase = new TaskBT[]
        {
            new Chase(agent,Player)
        };


        TaskNode patrolNode = new TaskNode("patrolNod1", tasksPatrol);
        TaskNode waitNode = new TaskNode("waitNode", tasksWait);
        TaskNode chaseNode = new TaskNode("chaseNode", taskChase);
        Node seq1 = new Sequence("seq1", new[] { patrolNode, waitNode,chaseNode });

        rootBT = seq1;
        /*
        TaskBT[] tasks1 = new TaskBT[]
        {
            new DummyTask("A1", TaskState.Failure),
            new DummyTask("A2", TaskState.Success)
        };
        TaskBT[] tasks2 = new TaskBT[]
        {
            new DummyTask("B", TaskState.Success)
        };

        TaskNode tn1 = new TaskNode("TN1", tasks1);
        TaskNode tn2 = new TaskNode("TN2", tasks2);

        Sequence seq1 = new Sequence("SEQ1", new Node[] {tn1, tn2});
        rootBT = seq1;
        */
    }

    void Update()
    {
        rootBT.Evaluate();
    }
}