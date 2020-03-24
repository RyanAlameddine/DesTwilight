using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActivatorChain : Activator
{
    List<Activator> activators = new List<Activator>();

    [Command]
    public override void CmdActivate(GameObject gameObject)
    {
        
        foreach(Activator activator in activators)
        {
            if (activator is ActivatorChain) continue;
            activator.CmdActivate(gameObject);
        }
        gameObject.GetComponent<BoardGameObject>().Activator = null;
    }

    void Start()
    {
        GetComponent<BoardGameObject>().Activator = this;
        activators.AddRange(GetComponents<Activator>());
    }

}
