using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationActivator : Activator
{
    [SerializeField]
    GameObject prefab;

    public override void Activate(BoardGameObject gameObject)
    {
        if (chain)
        {
            chain.Activate(gameObject);
        }
        Instantiate(prefab);
        gameObject.Activator = null;
        
    }
}
