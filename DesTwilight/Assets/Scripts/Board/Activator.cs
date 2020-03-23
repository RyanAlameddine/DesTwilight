using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : MonoBehaviour
{
    [SerializeField]
    protected Activator chain;

    public abstract void Activate(BoardGameObject gameObject);

}
