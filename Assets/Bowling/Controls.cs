using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
           rb.AddForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-Vector3.forward);
        }
    }
}
