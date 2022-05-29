using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour
{
    public List<UCard> cards = new List<UCard>();
    [SerializeField] public CountDown countDownNextCard;
    [SerializeField] public CountDown countDownNextBook;
    [SerializeField] public GameObject empty;

    public UCard PickCardOnTop()
    {
        if(cards.Count > 0)
        {
            UCard card = cards[0];
            cards.Remove(card);
            return card;
        }
        else
        {
            throw new System.Exception("Your deck is empty");
        }
    }

    void Update()
    {
        empty.active = cards.Count == 0;
    }

    public UCard PickSpecificCard(UPrototypeCard card)
    {
        throw new System.Exception("PickSpecificCard Not Implemented");
    }


    public UCard PickCardRandom()
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

    public void AddCard(UCard card)
    {
        cards.Add(card);
        card.transform.parent = transform;
        card.transform.localPosition = Vector3.zero;
        card.transform.Rotate(new Vector3(0, 0, 180));
    }

    public void AddCards(UCard[] collectionCards)
    {
        foreach (var card in collectionCards)
        {
            AddCard(card);
        }
    }

    public bool isEmpty()
    {
        return cards.Count == 0;
    }
}
