using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public float speed = 1f;
    private float fallMultiplayer = 2.6f;
    private float jumpMultiplayer = 2f;
    public float jumpVelocity = 1f;
    private Rigidbody rb;
    private bool grounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))// && grounded)
        {
            transform.position += Vector3.up * jumpVelocity * speed * Time.deltaTime;
            //transform.position += Vector3.forward * 2;
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            //rb.velocity = Vector3.up * jumpVelocity;
            //rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0));
            transform.position += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0));
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplayer * Time.deltaTime;
        }
        if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * jumpMultiplayer * Time.deltaTime;
        }
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = true;

        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "ground")
        {
            grounded = false;
            transform.position += Vector3.down * 2;
            Debug.Log("spadaj");
        }
    }*/
}

