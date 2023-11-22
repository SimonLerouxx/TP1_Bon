using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemiAnimation : MonoBehaviour
{
    Animator animator;
    [SerializeField] NavMeshAgent agent;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            animator.Play("Jump");
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.Play("walking");
        }
    }
}
