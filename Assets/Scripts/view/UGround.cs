using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UGround : MonoBehaviour
{
    public Transform area;
    public static int MAX_CARDS_HAND = 5;
    public List<UCard> cards = new List<UCard>();
    public UEmplacementCard[] emplacements;
    public UBoard boardPlayer;

    public void AppendCard(int index, UCard card)
    {
        if(cards.Count >= MAX_CARDS_HAND )
        {
            throw new System.Exception("Your hand is full, you can add card");
        }
        else
        {
            cards.Add(card);
            card.transform.parent = emplacements[index].transform;
            card.transform.position = emplacements[index].transform.position;
            emplacements[index].card = card;
            Vector3 position = card.transform.position;
            position.y = .2f;
            card.transform.position = position;
        }
    }

    public UCard DestroyCard(int index)
    {
        UCard card = emplacements[index].card;
        
        if(!cards.Remove(card))
        {
            throw new System.Exception("Card cant remove from Ground");
        }

        emplacements[index].card = null;
        GameManager.Instance.AddParticlesToCard(card);
        Destroy(card.gameObject, 1f);
        
        return card;
    }

    public int GetIndexFromCard(UCard card)
    {
        foreach (var place in emplacements)
        {
            if(place.card == card)
            {
                return place.index;
            }
        }
        return -1;
    } 
}