using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesUCard
{
    public UBoard board;
    public model.Card card;
    public GameObject frontcard;
}

public class UCard : MonoBehaviour
{
    protected UBoard boardPlayer;
    public model.Card card;
    protected CountDown countDown;
    protected Sprite frontcard;
    protected GameObject backcard;
    protected int index;
    protected bool animeAttak = false;
    protected UPrototypeCard proto;
    public UEmplacementCard empplacement;

    public UBoard Board
    {
        get {return boardPlayer;}
    }

    public UPrototypeCard Prototype
    {
        get { return proto; }
    }

    public void PlayCard()
    {
        card.emplacement.board.PlayCard(card, card.emplacement);
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

    public static UCard CreateCard(UPrototypeCard proto, Transform transform, PropertiesUCard propertiesUCard)
    {
        PrefabsManager instance1 = PrefabsManager.Instance;
        GameObject instance = Instantiate(PrefabsManager.Instance.prefabCard, transform);
        UCard uCard = instance.GetComponent<UCard>();
        uCard.proto = proto;
        
        if(propertiesUCard is not null)
        {
            uCard.boardPlayer = propertiesUCard.board;
            uCard.card = propertiesUCard.card;
            uCard.frontcard = proto.sprite;
        }

        return uCard;
    }

    private void Update()
    {
        if(animeAttak)
        {
            float tween = Mathf.Clamp(Mathf.Sin(Time.deltaTime), 0, 1);
            Vector3 position = transform.position;
            position.x += position.x * Time.deltaTime;
            transform.position = position;
        }
    }
}