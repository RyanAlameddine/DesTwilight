using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]
    new Camera camera;
    [SerializeField]
    float movementSensitivity = 1000f;
    
    public const float HandRotationSensitivity = 3f;


    [SerializeField]
    GameObject cursor;

    [SerializeField]
    GameObject activateSuggestion;

    [SerializeField]
    GameObject dealSuggestion;

    //bool rotating = false;
    [SerializeField]
    SmoothMouseLook look;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Confined;
        //transform.LookAt(transform.parent);
    }

    void Update()
    {
        //Rotation
        //if (Input.GetMouseButtonDown(1)) { rotating = true; }
        //if (Input.GetMouseButtonUp(1)) { rotating = false; }
        //if (rotating)
        //{
        //    transform.RotateAround(transform.parent.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivityX);

        //    float rotateDegrees = -Input.GetAxis("Mouse Y") * sensitivityY;
        //    //float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).x > 0 ? 1 : -1);
        //    float angleBetween = transform.eulerAngles.x;
        //    float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, rotationRange.x, rotationRange.y);
        //    rotateDegrees = newAngle - angleBetween;

        //    transform.RotateAround(transform.parent.position, transform.right, rotateDegrees);


        //    //transform.RotateAround(transform.parent.position, transform.right, -Input.GetAxis("Mouse Y") * sensitivityY);
        //}

        if (Input.GetMouseButtonDown(1))
        {
            look.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;

        }
        if (Input.GetMouseButtonUp(1))
        {
            look.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Cursor
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, 1000);

        //if (rotating)
        //{
        //    transform.LookAt(hit.point, Vector3.up);
        //}

        Hit(hit, ray);


        if (Mathf.Abs(Input.mouseScrollDelta.y) > 0)
        {
            camera.fieldOfView += Input.mouseScrollDelta.y;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 20, 100);
        }
    }

    BoardGameObject objInHand;
    void Hit(RaycastHit hit, Ray ray)
    {
        if (!hit.collider) 
        {
            cursor.transform.position = ray.direction * 100 + ray.origin;
            return;
        }
        
        cursor.transform.position = hit.point;
        var game = hit.collider.GetComponent<BoardGameObject>();

        if (objInHand == null)
        {
            if (game && Input.GetKeyDown(KeyCode.L))
            {
                game.Locked = !game.Locked;
                return;
            }
            if(game is Card)
            {
                dealSuggestion.SetActive(true);
            }
            else
            {
                dealSuggestion.SetActive(false);
            }
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            if (objInHand != null)
            {
                activateSuggestion.SetActive(false);
                objInHand.Release();
            }
            objInHand = game;
            if (objInHand)
            {
                if (objInHand.Locked)
                {
                    objInHand = null;
                    return;
                }
                //pickup card from deck
                if (game is Card card && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    objInHand = card.Deal().GetComponent<Card>();
                    objInHand.enabled = true;
                    objInHand.gameObject.SetActive(true);
                    objInHand.Hold();
                    objInHand.transform.position = hit.point + new Vector3(0, .4f + objInHand.carryingHeightOffset, 0);
                    
                }
                //pickup non-card
                else
                {
                    objInHand.Hold();
                }
                if(objInHand.Activator != null)
                {
                    activateSuggestion.SetActive(true);
                }
            }
        }else if (Input.GetMouseButton(0))
        {
            if (objInHand)
            {
                objInHand.transform.position = hit.point + new Vector3(0, .4f + objInHand.carryingHeightOffset, 0);
            }
        }else if (Input.GetMouseButtonUp(0))
        {
            if (objInHand)
            {
                objInHand.Release();
                activateSuggestion.SetActive(false);
                objInHand = null;
            }
        }
    }

    void FixedUpdate()
    {
        //Movement
        //Vector3 forward = transform.forward;
        //forward.y = 0;
        //forward.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(transform.forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(-transform.forward * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(-transform.right * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(transform.right * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rigidBody.AddForce(transform.up * movementSensitivity);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rigidBody.AddForce(-transform.up * movementSensitivity);
        }
    }
}
