using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform area;
    public static int MAX_CARDS_HAND = 5;

    public List<Card> cards = new List<Card>();
    public GameObject[] places;

    void Update()
    {
        placeCards();
    }

    public void placeCards()
    {
        for (int index = 0; index < cards.Count; index++)
        {
            if(cards[index])
            {
                cards[index].transform.position = places[index].transform.position;
            }
        }
    }

    public bool HandIsFull()
    {
        return cards.Count >= MAX_CARDS_HAND;
    }

    public void AppendCard(Card card)
    {
        if(cards.Count >= MAX_CARDS_HAND )
        {
            throw new System.Exception("Your hand is full, you can add card");
        }
        else
        {
            cards.Add(card);
            card.transform.parent = transform;
        }
    }

    public void Discard(Card card)
    {
        if(cards.Count == 0)
        {
            throw new System.Exception("Hand is empty, cant discard");
        }
        if(!cards.Remove(card))
        {
            throw new System.Exception("Cant discard card not in hand");
        }
    }

    public Card DiscardRandom()
    {
        Card card = cards[Random.Range(0, cards.Count)];
        Discard(card);
        return card;
    }
}
