using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorChain : Activator
{
    List<Activator> activators = new List<Activator>();

    public override void Activate(BoardGameObject gameObject)
    {
        
        foreach(Activator activator in activators)
        {
            if (activator is ActivatorChain) continue;
            activator.Activate(gameObject);
        }
        gameObject.Activator = null;
    }

    void Start()
    {
        GetComponent<BoardGameObject>().Activator = this;
        activators.AddRange(GetComponents<Activator>());
    }

}
