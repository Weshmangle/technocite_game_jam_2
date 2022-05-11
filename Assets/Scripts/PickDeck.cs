using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour
{
    public float currentTime = 0f;
    
    public List<Card> cards = new List<Card>();

    void Start()
    {
    }

    void Update()
    {
        if(currentTime > GameManager.TIME_OUT_NEXT_CARD)
        {
            PickCard();
            currentTime = 0f;
        }
        else
        {
            currentTime += Time.deltaTime;   
        }
    }

    public void PickCard()
    {
        if(cards.Count > 0)
        {
            Card card = cards[0];
            cards.Remove(card);
            Hand.Instance.AppendCard(card);
        }
    }

    public void AddCard(Card[] collectionCards)
    {
        foreach (var card in collectionCards)
        {
            cards.Add(card);
            card.transform.parent = transform;
            card.transform.localPosition = Vector3.zero;
        }
    }
}
