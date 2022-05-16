using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform area;
    public static int MAX_CARDS_HAND = 5;

    public List<Card> cards = new List<Card>();
    public GameObject[] places;
    public List<Card> cardsAnimated = new List<Card>();

    void Update()
    {
        placeCards();
        
        foreach (var card in cards)
        {
            if(cardsAnimated.Contains(card))
            {
                Vector3 position = places[card.index].transform.position - card.transform.position;
                float v = Quaternion.Angle(places[card.index].transform.rotation, card.transform.rotation);
                
                if(Mathf.Approximately(0.0f, v))
                {
                    card.transform.rotation = Quaternion.identity;
                    cardsAnimated.Remove(card);
                }
                else
                {
                    card.transform.Translate(position * Time.deltaTime);
                    card.transform.Rotate(new Vector3(0, 0, v) * Time.deltaTime * 2);
                }
            }            
        }
    }

    public void placeCards()
    {
        for (int index = 0; index < cards.Count; index++)
        {
            if(cards[index] && !cardsAnimated.Contains(cards[index]))
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
            card.index = cards.Count;
            card.transform.parent = transform;
            cards.Add(card);
            cardsAnimated.Add(card);
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
