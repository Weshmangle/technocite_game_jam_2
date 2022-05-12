using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public BoardPlayer boardPlayer;
    public PrototypeCard prottotypeCard;

    public void PlayCard()
    {
        
    }

    public static Card CreateCard(PrototypeCard proto)
    {
        GameObject instance = Instantiate(GameManager.Instance.prefabCard);
        Card card = instance.GetComponent<Card>();
        card.prottotypeCard = proto;
        return card;
    }
}
