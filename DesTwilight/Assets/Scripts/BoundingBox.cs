using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    [SerializeField]
    Transform respawnPoint;
    private void OnTriggerExit(Collider other)
    {
        other.transform.position = respawnPoint.position;
        var rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

}
