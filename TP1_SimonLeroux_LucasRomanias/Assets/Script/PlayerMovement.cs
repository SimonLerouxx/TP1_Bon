using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;


//Travail fait par SImon Leroux et Lucas Romanias

public class PlayerMovement : MonoBehaviour
{

    Vector3 deplacement;
    float speed = 5;
    [SerializeField] GameObject Camera;
    [SerializeField] float jumpForce = 75;
    Rigidbody rb;
    bool canJump = false;

    float speedSprint=8;
    float speedNormal = 5;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(deplacement == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {

            animator.SetBool("isJumping", false);
        }
        transform.Translate(deplacement *Time.deltaTime*speed,Space.Self);

        
    }





    public void Move(InputAction.CallbackContext ctx)
    {
        
        if(ctx.performed)
        {
            animator.SetBool("isWalking", true);
            deplacement = ctx.ReadValue<Vector3>();
        }
        
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canJump)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector3(0, jumpForce, 0));
            speed = speedNormal;
            canJump = false;
        }
    }

    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canJump)
        {
            animator.SetBool("isRunning", true);
            speed = speedSprint;
        }
        else if (ctx.canceled)
        {
            animator.SetBool("isRunning", false);
            speed = speedNormal;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Sol")
        {
            canJump = true;
        }
    }
}
