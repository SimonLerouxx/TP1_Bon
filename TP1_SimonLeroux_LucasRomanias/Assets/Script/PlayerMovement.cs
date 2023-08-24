using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 deplacement;
    float speed = 5;
    [SerializeField] GameObject Camera;
    [SerializeField] float jumpForce = 75;
    Rigidbody rb;
    bool canJump = false;

    float speedSprint=10;
    float speedNormal = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(deplacement *Time.deltaTime*speed,Space.Self);
       
    }



    public void Move(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            deplacement = ctx.ReadValue<Vector3>();
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canJump)
        {
            
            rb.AddForce(new Vector3(0, jumpForce, 0));
            speed = speedNormal;
            canJump = false;
        }
    }

    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canJump)
        {
            speed = speedSprint;
        }
        else if (ctx.canceled)
        {
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
