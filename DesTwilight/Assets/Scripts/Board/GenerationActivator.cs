using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GenerationActivator : Activator
{
    [SerializeField]
    GameObject prefab;

    [Command]
    public override void CmdActivate(GameObject gameObject)
    {
        if (chain)
        {
            chain.CmdActivate(gameObject);
        }
        GameObject obj = Instantiate(prefab);
        NetworkServer.Spawn(obj);
        gameObject.GetComponent<BoardGameObject>().Activator = null;
        
    }
}
