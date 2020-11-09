using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public float moveSpeed = 1f;
    private Animator animator;
    private bool frogIsMoving = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        frogIsMoving = true;
    }

    public void stopFrogMovement()
    {
        frogIsMoving = false;
    }

    public void startFrogMovement()
    {
        frogIsMoving = true;
    }

    void Update()
    {
        if (frogIsMoving)
        {
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;

            moveDirection.x = 0;
            moveDirection.z = 0;

            animator.SetBool("jumping", controller.isGrounded == false);
            moveDirection += transform.forward * moveSpeed;
            animator.SetBool("walking", true);

            if (Input.GetKey(KeyCode.LeftArrow) && controller.isGrounded)
            {
                transform.Rotate(new Vector3(0, -1, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow) && controller.isGrounded)
            {
                transform.Rotate(new Vector3(0, 1, 0));
            }

            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}

