using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShooterMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private Transform cameraHolder;
    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float mouseSensitivityX = 100f;

    [SerializeField]
    private float mouseSensitivityY = 100f;

    private bool isGrounded = false;

    [SerializeField]
    private float jumpSpeed = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Grounded();
        Rotation();
        Movement();
    }

    private void Grounded()
    {
        if(Physics.Raycast(groundChecker.position, Vector3.down, 0.03f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        float xRotation = cameraHolder.rotation.eulerAngles.x;
        xRotation -= mouseY;

        if(xRotation > 180)
            xRotation -= 360;
            
        xRotation = Mathf.Clamp(xRotation, -80, 90);
        
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    private void Movement() { 
        // pøidat jump
        // zamezit otáèení hráèe pøi nárazu

        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        float currentYSpeed = rb.linearVelocity.y;

        if (isGrounded && Input.GetButtonDown("Jump"))
            currentYSpeed = jumpSpeed;

        Vector3 newVelocity = new Vector3(horMove, 0, verMove) * speed;
        Vector3 rotatedVelocity = transform.rotation * newVelocity;

        rotatedVelocity.y = currentYSpeed;

        rb.linearVelocity = rotatedVelocity;
    }
}
