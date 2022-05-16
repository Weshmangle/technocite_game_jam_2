using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ground : MonoBehaviour
{
    public Transform area;
    public static int MAX_CARDS_HAND = 5;
    public List<Card> cards = new List<Card>();
    public PlaceCardGround[] places;
    public BoardPlayer boardPlayer;

    public void AppendCard(int index, Card card)
    {
        if(cards.Count >= MAX_CARDS_HAND )
        {
            throw new System.Exception("Your hand is full, you can add card");
        }
        else
        {
            cards.Add(card);
            card.transform.parent = places[index].transform;
            card.transform.position = places[index].transform.position;
            places[index].card = card;
            Vector3 position = card.transform.position;
            position.y = .2f;
            card.transform.position = position;
        }
    }

    public Card DestroyCard(int index)
    {
        Card card = places[index].card;
        
        if(!cards.Remove(card))
        {
            throw new System.Exception("Card cant remove from Ground");
        }

        places[index].card = null;
        GameManager.Instance.AddParticlesToCard(card);
        Destroy(card.gameObject, 1f);
        
        return card;
    }

    public int GetIndexFromCard(Card card)
    {
        foreach (var place in places)
        {
            if(place.card == card)
            {
                return place.index;
            }
        }
        return -1;
    } 
}