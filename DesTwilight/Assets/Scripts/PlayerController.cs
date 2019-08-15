using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField]
    float sensitivityX = 1F;
    [SerializeField]
    float sensitivityY = 1F;
    [SerializeField]
    float movementSensitivity = 1000f;

    bool rotating = false;

    void Start()
    {
        rigidBody = transform.parent.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        transform.LookAt(transform.parent);
    }

    void Update()
    {
        //Rotation
        if (Input.GetMouseButtonDown(1)) { rotating = true; }
        if (Input.GetMouseButtonUp(1)) { rotating = false; }
        if (rotating)
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, Input.GetAxis("Mouse X") * sensitivityX);
            transform.RotateAround(transform.parent.position, transform.right, -Input.GetAxis("Mouse Y") * sensitivityY);
        }

        //Movement

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        if (Input.GetKey(KeyCode.W)){
            rigidBody.AddForce(forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.S)){
            rigidBody.AddForce(-forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.A)){
            rigidBody.AddForce(-transform.right * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.D)){
            rigidBody.AddForce(transform.right * movementSensitivity);
        }

    }

    void FixedUpdate()
    {
        
    }
}
