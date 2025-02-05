using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShooterMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private Transform cameraHolder;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float mouseSensitivityX = 100f;

    [SerializeField]
    private float mouseSensitivityY = 100f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotation();
        Movement();
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        float xRotation = cameraHolder.rotation.eulerAngles.x;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, 90);
        
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    private void Movement()
    {   // opravit oriented movement
        // pøidat jump
        // zamezit otáèení hráèe pøi nárazu

        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        Vector3 newVelocity = new Vector3(horMove, 0, verMove) * speed;
        rb.linearVelocity = newVelocity;
    }
}
