using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TileDisplay : NetworkBehaviour
{
    public Transform[] children;
    public Vector3[] startPositions;

    private void Start()
    {
        if (!isServer)
        {
            children = new Transform[0];
            enabled = false;
            return;
        }
        children = new Transform[transform.childCount];
        startPositions = new Vector3[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i);
            startPositions[i] = children[i].position;
        }
    }

    private void Update()
    {
        for(int i = 0; i < children.Length; i++)
        {
            if (children[i] == null) continue;
            Vector3 pos = startPositions[i];
            Quaternion rot = children[i].rotation;
            pos = new Vector3(pos.x, transform.position.y + Mathf.Sin(Time.time + i), pos.z);
            children[i].transform.position = pos;
            //children[i].velocity = (pos - children[i].position)*10;
        }
    }
}
