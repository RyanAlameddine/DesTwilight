using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTileSetup : MonoBehaviour
{
    [SerializeField]
    Transform zeroZeroTransform;

    [SerializeField]
    GameObject tileMagnetPrefab;

    private void Start()
    {
        GameObject[] objects = new GameObject[37];
        for(int i = 0; i < 37; i++)
        {
            objects[i] = Instantiate(tileMagnetPrefab);
        }
        Setup(objects);
    }

    public void Setup(GameObject[] objects)
    {
        int column = 0;
        int columnSize = 4;
        int columnI = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 offset = new Vector3(-column * Mathf.Sqrt(3) / 2, 0, columnI - 1/2f*(columnSize - 4));
            //Debug.Log(offset);
            GameObject instance = objects[i];
            instance.transform.parent = zeroZeroTransform;
            instance.transform.localPosition = offset;

            columnI++;
            if (columnI >= columnSize)
            {
                columnI = 0;
                column++;
                if (column > 3)
                {
                    columnSize--;
                }
                else
                {
                    columnSize++;
                }
            }
        }
    }
}
