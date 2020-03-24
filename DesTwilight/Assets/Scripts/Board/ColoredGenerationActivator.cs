using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColoredGenerationActivator : Activator
{
    [SerializeField]
    GameObject[] prefabs;
    [SerializeField]
    int[] counts;

    [SerializeField]
    Material material;

    [Command]
    public override void CmdActivate(GameObject gameObject)
    {
        if (chain)
        {
            chain.CmdActivate(gameObject);
        }
        int y = 2;
        for (int i = 0; i < prefabs.Length; i++)
        {
            for(int j = 0; j < counts[i]; j++)
            {
                y++;
                GameObject obj = Instantiate(prefabs[i], transform.position + new Vector3(0, y, 0), transform.rotation);
                obj.GetComponent<MeshRenderer>().material = material;
                NetworkServer.Spawn(obj);
            }
        }
        gameObject.GetComponent<BoardGameObject>().Activator = null;
        Destroy(gameObject.gameObject);
    }
}
