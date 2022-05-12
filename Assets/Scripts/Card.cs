using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public BoardPlayer boardPlayer;
    public PrototypeCard prottotypeCard;
    public SpriteRenderer spriteFront;

    public void PlayCard()
    {
        
    }

    public void SetPrototype(PrototypeCard proto)
    {
        prottotypeCard = proto;
        spriteFront.sprite = proto.sprite;
    }

    public static Card CreateCard(PrototypeCard proto)
    {
        GameObject instance = Instantiate(GameManager.Instance.prefabCard);
        Card card = instance.GetComponent<Card>();
        card.SetPrototype(proto);
        return card;
    }
}
