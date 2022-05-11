using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public Card PickCard()
    {
        if(cards.Count > 0)
        {
            Card card = cards[0];
            cards.Remove(card);
            return card;
        }
        return null;
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
