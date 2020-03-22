using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSnapper : MonoBehaviour
{
    BoardGameObject target;
    [SerializeField]
    BoardGameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        var boardObj = other.GetComponent<BoardGameObject>();
        if (boardObj && !boardObj.IgnoreSnapping)
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
            if (parent && parent.holding)
            {
                target = null;
                return;
            }
            if (target.holding)
            {
                target = null;
                return;
            }
            target.transform.position = Vector3.Lerp(target.transform.position, transform.position, .1f);
            
        }
    }
}
