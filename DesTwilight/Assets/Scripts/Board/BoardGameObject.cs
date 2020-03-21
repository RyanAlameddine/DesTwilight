using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoardGameObject : MonoBehaviour
{
    public Collider Collider { get; private set; }
    public bool Locked { get; set; }

    new Rigidbody rigidbody;
    public bool holding { get; private set; } = false;

    bool flipped = false;

    Quaternion targetRotation = Quaternion.identity;

    public void Start()
    {
        Collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (holding)
        {
            float yRot = 0;

            if (Input.GetKey(KeyCode.E))
            {
                yRot += PlayerController.HandRotationSensitivity;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                yRot -= PlayerController.HandRotationSensitivity;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                flipped = !flipped;
            }

            if (flipped)
            {
                targetRotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                targetRotation = Quaternion.identity;
            }

            Quaternion rotation = Quaternion.Lerp(transform.localRotation, targetRotation, .2f);
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, transform.localRotation.eulerAngles.y + yRot, rotation.eulerAngles.z);
            transform.localRotation = rotation;
        }
    }

    public void Hold()
    {
        holding = true;
        Collider.enabled = false;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
    }

    public void Release()
    {
        holding = false;
        Collider.enabled = true;
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            float y = transform.localRotation.eulerAngles.y;
            y = Mathf.Round(y / 30) * 30;
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, y, transform.localRotation.eulerAngles.z);
        }
    }
}
