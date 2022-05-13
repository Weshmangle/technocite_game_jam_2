using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public BoardPlayer boardPlayer;
    public PrototypeCard prottotypeCard;
    public SpriteRenderer spriteFront;
    public CountDown countDown;

    public void PlayCard()
    {
        foreach (var effect in prottotypeCard.effects)
        {
            effect.Execute(this);
        }
    }

    public void SetPrototype(PrototypeCard proto)
    {
        prottotypeCard = proto;
        spriteFront.sprite = proto.sprite;
    }

    public void StartTimer(float startTime)
    {
        countDown.gameObject.SetActive(true);
        countDown.SetTimeOut(startTime);
        countDown.StartCoundtDown();
    }

    public static Card CreateCard(PrototypeCard proto)
    {
        GameObject instance = Instantiate(GameManager.Instance.prefabCard);
        Card card = instance.GetComponent<Card>();
        card.SetPrototype(proto);
        return card;
    }
}