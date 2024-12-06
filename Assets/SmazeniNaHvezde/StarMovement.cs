using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) { movement.z = 1; }
        if (Input.GetKey(KeyCode.S)) { movement.z = -1; }
        if (Input.GetKey(KeyCode.A)) { movement.x = -1; }
        if (Input.GetKey(KeyCode.D)) { movement.x = 1; }

        // snížení max rychlosti na 1 i do více stran najednou
        movement = Vector3.ClampMagnitude(movement, 1);
        
        rb.AddForce(movement * force * Time.deltaTime);
    }
}
