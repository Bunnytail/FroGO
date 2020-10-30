using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //rigidbody.velocity = Vector3.forward * speed;
        rigidbody.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 100f);
            Debug.Log("skacz");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
