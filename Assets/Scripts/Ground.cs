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
            Vector3 position = card.transform.position;
            position.y = .2f;
            card.transform.position = position;
        }
    }
}
