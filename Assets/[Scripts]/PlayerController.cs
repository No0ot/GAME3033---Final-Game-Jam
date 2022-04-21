using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;

    public float runForce = 3;
    public float maxSpeed = 20;
    public float jumpForce = 2;

    Vector2 inputVector;

    bool isGrounded;
    bool canDoubleJump;

    public Transform groundCheck;
    public float groundRadius = 0.4f;
    public LayerMask groundMask;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>().normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded)
        {
            canDoubleJump = true;
            animator.SetBool("IsGrounded", true);
            Rotate();
        }
        else
            animator.SetBool("IsGrounded", false);
        Move();
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(inputVector.x, 0.0f);
        moveDirection.Normalize();

        if (isGrounded)
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
                rigidbody.AddForce(moveDirection * (runForce * rigidbody.mass));
        }
        else
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
                rigidbody.AddForce(moveDirection * (runForce * rigidbody.mass) / 2);
        }


        animator.SetFloat("Speed", rigidbody.velocity.magnitude / maxSpeed);

    }

    void OnJump(InputValue value)
    {
        if(canDoubleJump)
        {
            if(isGrounded)
            {
                Jump();
                return;
            }
            DoubleJump();
            return;
        }
    }

    void Jump()
    {
        isGrounded = false;
        rigidbody.AddForce(transform.up * (jumpForce * rigidbody.mass), ForceMode.Impulse);

        Vector2 moveDirection = new Vector2(inputVector.x, 0.0f);
        moveDirection.Normalize();

        if (rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(moveDirection * jumpForce);
        
        animator.SetTrigger("Jump");
    }

    void DoubleJump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);

        if((inputVector.x > 0 && rigidbody.velocity.x < 0) || (inputVector.x < 0 && rigidbody.velocity.x > 0))
        {
            rigidbody.velocity = new Vector3(0, 0, rigidbody.velocity.z);
            Vector2 moveDirection = new Vector2(inputVector.x, 0.0f);
            moveDirection.Normalize();

            if (rigidbody.velocity.magnitude < maxSpeed)
                rigidbody.AddForce(moveDirection * (jumpForce * rigidbody.mass));
            //Debug.Log("STUFFF");
        }

        rigidbody.AddForce(transform.up * (jumpForce * rigidbody.mass), ForceMode.Impulse);
        canDoubleJump = false;

        animator.SetTrigger("SecondJump");

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    void Rotate()
    {
        if(inputVector.x > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720.0f * Time.deltaTime);
        }
        else if(inputVector.x < 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720.0f * Time.deltaTime);
        }
    }
}
