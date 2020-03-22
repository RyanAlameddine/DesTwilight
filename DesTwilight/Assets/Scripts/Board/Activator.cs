using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardGameObject))]
public abstract class Activator : MonoBehaviour
{
    public abstract void Activate(BoardGameObject gameObject);
}
