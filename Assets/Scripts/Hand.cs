using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand Instance;
    public Transform area;
    public static int MAX_CARDS_HAND = 5;

    public List<Card> cards = new List<Card>();
    public GameObject[] places;
    
    void Start()
    {
        Instance = this;
    }

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
}
