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
        else
        {
            throw new System.Exception("Your deck is empty");
        }
    }

    public Card PickSpecificCard(PrototypeCard card)
    {
        throw new System.Exception("PickSpecificCard Not Implemented");
    }


    public Card PickCardRandom()
    {
        if(cards.Count == 0)
        {
            throw new System.Exception("Your deck is empty");
        }
        else
        {
            return cards[Random.Range(0, cards.Count)];
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
