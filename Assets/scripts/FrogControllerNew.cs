using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogControllerNew : MonoBehaviour
{
    public float gravity = 100.0f;

    private CharacterController cc;
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // && cc.isGrounded)
        {
            anim.SetTrigger("Jump");
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }

        if(cc.isGrounded)
        {
            moveDirection.y = 0.0f;
        }
        else 
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        cc.Move(moveDirection * Time.deltaTime);

    }
}
