using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesUCard
{
    public UBoard board;
    public model.Card card;
    public GameObject backcard;
    public GameObject frontcard;
}

public class UCard : MonoBehaviour
{
    protected UBoard boardPlayer;
    protected model.Card card;
    protected CountDown countDown;
    protected GameObject frontcard;
    protected GameObject backcard;
    protected int index;
    protected bool animeAttak = false;

    public UBoard Board
    {
        get {return boardPlayer;}
    }

    public void PlayCard()
    {
        card.emplacement.board.PlayCard(card, card.emplacement);
        throw new NotImplementedException("TO DO");
    }

    public void SetProps(UBoard board, model.Card card, GameObject backcard, GameObject frontcard)
    {
        this.boardPlayer = board;
        this.card = card;
        this.backcard = backcard; 
        this.frontcard = frontcard; 
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

    public static UCard CreateCard(UPrototypeCard proto, Transform transform, PropertiesUCard propertiesUCard = null)
    {
        GameObject instance = Instantiate(PrefabsManager.Instance.prefabCard, transform);
        UCard uCard = instance.GetComponent<UCard>();
        
        if(propertiesUCard is not null)
        {
            uCard.boardPlayer = propertiesUCard.board;
            uCard.card = propertiesUCard.card; 
            uCard.backcard = propertiesUCard.backcard;
            uCard.frontcard = propertiesUCard.frontcard;
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