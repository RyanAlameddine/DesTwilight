using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    new Camera camera;

    [SerializeField]
    float sensitivityX = 1F;
    [SerializeField]
    float sensitivityY = 1F;
    [SerializeField]
    float movementSensitivity = 1000f;


    [SerializeField]
    GameObject cursor;


    [SerializeField]
    Vector2 rotationRange = new Vector2(3, 89);

    bool rotating = false;

    void Start()
    {
        rigidBody = transform.parent.GetComponent<Rigidbody>();
        camera = GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Confined;
        transform.LookAt(transform.parent);
    }

    void Update()
    {
        //Rotation
        if (Input.GetMouseButtonDown(1)) { rotating = true; }
        if (Input.GetMouseButtonUp(1)) { rotating = false; }
        if (rotating)
        {
            transform.RotateAround(transform.parent.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivityX);

            float rotateDegrees = -Input.GetAxis("Mouse Y") * sensitivityY;
            //float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).x > 0 ? 1 : -1);
            float angleBetween = transform.eulerAngles.x;
            float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, rotationRange.x, rotationRange.y);
            rotateDegrees = newAngle - angleBetween;

            transform.RotateAround(transform.parent.position, transform.right, rotateDegrees);


            //transform.RotateAround(transform.parent.position, transform.right, -Input.GetAxis("Mouse Y") * sensitivityY);
        }
        
        
        //Cursor
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, 1000);
        if (hit.collider)
        {
            cursor.transform.position = hit.point;
        }
        else{

            cursor.transform.position = ray.direction * 100 + ray.origin;
        }

        if(Mathf.Abs(Input.mouseScrollDelta.y) > 0)
        {
            transform.position += transform.forward * Input.mouseScrollDelta.y;
        }
    }

    void FixedUpdate()
    {
        //Movement
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(-forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(-transform.right * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(transform.right * movementSensitivity);
        }
    }
}
