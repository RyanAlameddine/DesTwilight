using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int count;
    [SerializeField]
    bool slightRandom = false;

    private void Start()
    {
        int y = 0;
        for(int i = 0; i < count; i++)
        {
            Vector3 offset;
            if (slightRandom)
            {
                offset = new Vector3(Random.Range(-2f, 2), y, Random.Range(-2f, 2));
            }
            else
            {
                offset = new Vector3(0, y, 0);
            }
            GameObject instance = Instantiate(prefab, transform.position + offset, Quaternion.identity);
            y += 1;

        }
    }
}
