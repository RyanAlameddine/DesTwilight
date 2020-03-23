using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoardGameObject : MonoBehaviour
{
    public Collider Collider { get; private set; }
    public bool Locked { get; set; }

    protected new Rigidbody rigidbody;
    public bool holding { get; protected set; } = false;

    protected bool flipped = false;

    [SerializeField]
    public bool IgnoreSnapping = true;

    Quaternion targetRotation = Quaternion.identity;

    public Activator Activator;

    public float carryingHeightOffset = 0;

    public void Start()
    {
        Collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (holding)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flipped = !flipped;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (Activator)
                {
                    Activator.Activate(this);
                    if (!Activator)
                    {
                        GameObject gameObject = GameObject.Find("ActivateSuggestion");
                        gameObject.SetActive(false);
                    }
                }
            }
        }
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

            if (flipped)
            {
                targetRotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                targetRotation = Quaternion.identity;
            }

            Quaternion localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 0, transform.localRotation.eulerAngles.z);
            Quaternion rotation = Quaternion.Lerp(localRotation, targetRotation, .2f);
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, transform.localRotation.eulerAngles.y + yRot, rotation.eulerAngles.z);
            transform.localRotation = rotation;
        }
    }

    public virtual void Hold()
    {
        holding = true;
        Collider.enabled = false;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
    }

    public virtual void Release()
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
