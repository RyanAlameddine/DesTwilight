using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChildrenActivator : Activator
{
    [SerializeField]
    TileDisplay display;

    public override void Activate(BoardGameObject gameObject)
    {
        foreach(var child in display.children)
        {
            if(child != display.transform)
            {
                Destroy(child.gameObject);
            }
        }
        display.children = new Transform[0];
        if(chain)
            chain.Activate(gameObject);
    }
}
