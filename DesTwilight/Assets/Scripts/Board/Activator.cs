using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Activator : NetworkBehaviour
{
    [SerializeField]
    protected Activator chain;

    [Command]
    public abstract void CmdActivate(GameObject gameObject);

}
