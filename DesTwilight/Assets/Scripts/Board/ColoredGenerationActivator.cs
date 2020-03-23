using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredGenerationActivator : Activator
{
    [SerializeField]
    GameObject[] prefabs;
    [SerializeField]
    int[] counts;

    [SerializeField]
    Material material;

    public override void Activate(BoardGameObject gameObject)
    {
        int y = 0;
        for (int i = 0; i < prefabs.Length; i++)
        {
            for(int j = 0; j < counts[i]; j++)
            {
                y++;
                Instantiate(prefabs[i], transform.position + new Vector3(0, y, 0), transform.rotation).GetComponent<MeshRenderer>().material = material;
            }
        }
        gameObject.Activator = null;
        Destroy(gameObject.gameObject);
    }
}
