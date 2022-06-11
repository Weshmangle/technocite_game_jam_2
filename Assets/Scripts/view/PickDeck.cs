using System.Collections.Generic;
using UnityEngine;

public class PickDeck : MonoBehaviour
{
    public List<UCard> cards = new List<UCard>();
    public model.Deck deck;
    [SerializeField] public GameObject empty;

    public UCard PickCardOnTop()
    {
        return PickCard(0);
    }

    public UCard PickCard(int index)
    {        
        if(cards.Count > 0)
        {
            UCard card = cards[0];
            cards.Remove(card);
            return card;
        }
        else
        {
            return null;
        }
    }

    void Update()
    {
        empty.SetActive(cards.Count == 0);
    }

    public UCard PickSpecificCard(model.Card card)
    {
        deck.PickSpecificCard(card);
        return PickCard(0);
    }

    public void AddCard(UCard card)
    {
        cards.Add(card);
        card.transform.parent = transform;
        card.transform.localPosition = Vector3.zero;
        card.transform.Rotate(new Vector3(0, 0, 180));
    }
}
