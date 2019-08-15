using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject which can be picked up and moved by the player
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    bool locked = false;

    [SerializeField]
    bool rotationLockedPickup = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
