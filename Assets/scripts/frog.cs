using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool grounded = false;
    


    public float speed;
    public float jump;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        //transform.position = transform.position + (Vector3.forward * speed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        //rigidbody.velocity = Vector3.forward * speed;
        //rigidbody.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
        if (Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);


            Debug.Log("skacz");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0));
            //transform.position += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0));
            //transform.position += Vector3.right;
        }

        
    }
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
        }
    }

}
