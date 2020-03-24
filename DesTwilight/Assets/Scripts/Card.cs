using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : BoardGameObject
{
    [SerializeField]
    List<GameObject> otherCards = new List<GameObject>();

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    BoxCollider trigger;

    [SerializeField]
    Transform middle;

    [SerializeField]
    TextMeshPro text1;
    [SerializeField]
    TextMeshPro text2;

    private new void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            Card card = other.gameObject.GetComponent<Card>();
            if (card)
            {
                otherCards.Add(card.gameObject);
                otherCards.AddRange(card.otherCards);
                card.otherCards.Clear();
                card.enabled = false;
                card.gameObject.SetActive(false);

                AdjustHeight();
            }
        }
    }

    public override void Hold()
    {
        trigger.enabled = false;
        base.Hold();
    }

    public override void Release()
    {
        trigger.enabled = true;
        base.Release();
    }

    void AdjustHeight()
    {
        var newVal = otherCards.Count / 30f + 1/30f;
        transform.localScale = new Vector3(transform.localScale.x, newVal, transform.localScale.z);
        carryingHeightOffset = newVal / 2f;
        newVal *= 100;
        middle.localScale = new Vector3(middle.localScale.x, newVal / (newVal + 1), middle.localScale.z);

        text1.text = otherCards.Count == 0 ? "" : (otherCards.Count + 1) + "";
        text2.text = text1.text;
    }

    public GameObject Deal()
    {
        if (otherCards.Count == 0)
        {
            return gameObject;
        }
        if (flipped)
        {
            GameObject newCard = otherCards[0];
            newCard.transform.position = transform.position;
            newCard.transform.rotation = transform.rotation;
            var card = newCard.GetComponent<Card>();
            card.otherCards.AddRange(otherCards);
            card.otherCards.RemoveAt(0);
            otherCards.Clear();
            newCard.SetActive(true);
            card.enabled = true;
            AdjustHeight();
            card.AdjustHeight();
            card.flipped = flipped;
            card.rigidbody.angularVelocity = Vector3.zero;
            card.rigidbody.velocity = Vector3.zero;
            return gameObject;
        }
        else
        {
            GameObject card = otherCards[otherCards.Count - 1];
            card.transform.position = transform.position;
            card.transform.rotation = transform.rotation;
            otherCards.Remove(card);
            var c = card.GetComponent<Card>();
            c.flipped = flipped;
            c.AdjustHeight();
            
            AdjustHeight();
            return card;
        }
    }
}
