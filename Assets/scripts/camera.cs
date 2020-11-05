using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform lookAT;
    private Vector3 offset;

        // Start is called before the first frame update
    void Start()
    {
        lookAT = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAT.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAT.position + offset;
    }
}
