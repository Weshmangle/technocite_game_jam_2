using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UHand : MonoBehaviour
{
    public static int MAX_CARDS_HAND = 5;

    public List<UCard> cards = new List<UCard>();
    public UEmplacementCard[] emplacements;
    public List<UCard> cardsAnimated = new List<UCard>();
    public GameObject prefabEmplacement;

    void Update()
    {
        placeCards();
        
        foreach (var card in cards)
        {
            if(cardsAnimated.Contains(card))
            {
                Vector3 position = card.empplacement.transform.position - card.transform.position;
                float angle = Quaternion.Angle(card.empplacement.transform.rotation, card.transform.rotation);
                
                if(Mathf.Approximately(0.0f, angle))
                {
                    card.transform.rotation = Quaternion.identity;
                    cardsAnimated.Remove(card);
                }
                else
                {
                    card.transform.position += position * Time.deltaTime * 1f;
                    card.transform.Rotate(new Vector3(0, 0, angle) * Time.deltaTime);
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
                cards[index].transform.position = emplacements[index].transform.position;
            }
        }
    }

    public bool HandIsFull()
    {
        return cards.Count >= MAX_CARDS_HAND;
    }

    public void AppendCard(UCard card)
    {
        foreach (var emplacement in emplacements)
        {
            if(emplacement.card == null)
            {
                card.transform.parent = emplacement.transform;
                emplacement.card = card;
                card.empplacement = emplacement;
                cards.Add(card);
                cardsAnimated.Add(card);
                return;       
            }
        }
        throw new System.Exception("Your hand is full, you can add card");
    }

    public void Discard(UCard card)
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

    public UCard DiscardRandom()
    {
        UCard card = cards[Random.Range(0, cards.Count)];
        Discard(card);
        return card;
    }
}
