using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public BoardPlayer boardPlayer;
    public PrototypeCard prottotypeCard;
    public SpriteRenderer spriteFront;
    public CountDown countDown;
    public int index;

    protected bool animeAttak = false;

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

    public void AnimeAttak()
    {
        animeAttak = true;
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
        instance.transform.Rotate(new Vector3(0,0,180));
        Card card = instance.GetComponent<Card>();
        card.SetPrototype(proto);
        return card;
    }

    private void Update()
    {
        if(animeAttak)
        {
            Vector3 position = transform.position;
            position.x += position.x * Time.deltaTime;
            transform.position = position;
        }
    }
}