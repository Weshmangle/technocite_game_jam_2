using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public Card PickCardOnTop()
    {
        if(cards.Count > 0)
        {
            Card card = cards[0];
            cards.Remove(card);
            return card;
        }
        return null;
    }

    public Card PickCardRandom()
    {
        if(cards.Count == 0)
        {
            throw new System.Exception("Your deck is empty");
        }

        return cards[Random.Range(0, cards.Count)];
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
