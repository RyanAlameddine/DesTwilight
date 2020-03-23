using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour
{
    public Transform[] children;
    public Vector3[] startPositions;

    private void Start()
    {
        children = GetComponentsInChildren<Transform>();
        startPositions = new Vector3[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            startPositions[i] = children[i].position;
        }
    }

    private void Update()
    {
        for(int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform) continue;
            Vector3 pos = startPositions[i];
            Quaternion rot = children[i].rotation;
            pos = new Vector3(pos.x, transform.position.y + Mathf.Sin(Time.time + i), pos.z);
            children[i].position = pos;
        }
    }
}
