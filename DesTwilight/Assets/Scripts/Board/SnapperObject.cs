using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapperObject : BoardGameObject
{
    [SerializeField]
    PositionSnapper[] snappers;
    public override void Hold()
    {
        foreach(var snapper in snappers)
        {
            snapper.target = null;
            snapper.enabled = false;
        }
        base.Hold();
    }

    public override void Release()
    {
        foreach (var snapper in snappers)
        {
            snapper.enabled = true;
        }
        base.Release();
    }
}
