using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform area;
    public static int MAX_CARDS_HAND = 5;

    public GameObject[] cards;
    public GameObject[] places;
    
    void Start()
    {
        cards = new GameObject[MAX_CARDS_HAND];
    }

    void Update()
    {
        placeCards();
    }

    public void placeCards()
    {
        for (int index = 0; index < cards.Length; index++)
        {
            if(cards[index])
            {
                cards[index].transform.position = places[index].transform.position;
            }
        }
    }
}
