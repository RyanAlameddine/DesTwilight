using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClearChildrenActivator : Activator
{
    [SerializeField]
    TileDisplay display;

    [Command]
    public override void CmdActivate(GameObject gameObject)
    {
        foreach(var child in display.children)
        {
            if(child != null)
            {
                Destroy(child.gameObject);
            }
        }
        display.children = new Transform[0];
        if(chain)
            chain.CmdActivate(gameObject);
    }
}
