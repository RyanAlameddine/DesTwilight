using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSnapper : MonoBehaviour
{
    BoardGameObject target;
    private void OnTriggerEnter(Collider other)
    {
        var boardObj = other.GetComponent<BoardGameObject>();
        if (boardObj)
        {
            target = boardObj;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            target = null;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            target.transform.position = Vector3.Lerp(target.transform.position, transform.position, .1f);
            if (target.holding)
            {
                target = null;
            }
        }
    }
}
