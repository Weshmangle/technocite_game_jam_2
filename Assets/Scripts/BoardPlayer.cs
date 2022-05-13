using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BoardPlayer : MonoBehaviour
{
    public PickDeck deck;
    public StarterDeck starterDeck;
    public Hand hand;
    public Ground ground;
    public float currentTime = 0f;

    public Card cardSelected;

   void Start()
   {
       foreach (var protoCard in starterDeck.cards)
       {
            Card card = Card.CreateCard(protoCard);
            card.boardPlayer = this;
            deck.AddCard(card);
       }

        for (int index = 0; index < ground.places.Length; index++)
        {
            PlaceCardGround placeCardGround = ground.places[index];
            placeCardGround.board = this;
            placeCardGround.index = index;
        }

       deck.countDownNextCard.SetTimeOut(GameManager.TIME_OUT_NEXT_CARD);
       deck.countDownNextCard.StartCoundtDown();
       deck.countDownNextBook.SetTimeOut(GameManager.TIME_OUT_NEXT_BOOK);
       deck.countDownNextBook.StartCoundtDown();
   }
    
    void Update()
    {
        if(currentTime > GameManager.TIME_OUT_NEXT_CARD)
        {
            if(!hand.HandIsFull() && !deck.isEmpty())
            {
                Card card = deck.PickCardOnTop();
                hand.AppendCard(card);
            }
            currentTime = 0f;
            deck.countDownNextCard.SetTimeOut(GameManager.TIME_OUT_NEXT_CARD);
            deck.countDownNextCard.StartCoundtDown();
            deck.countDownNextBook.SetTimeOut(GameManager.TIME_OUT_NEXT_BOOK);
            deck.countDownNextBook.StartCoundtDown();
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out raycastHit, 100f))
            {
                if(raycastHit.transform != null)
                {
                    Card card = raycastHit.transform.gameObject.GetComponent<Card>();

                    if(card)
                    {
                        if(card.boardPlayer.name == name)
                        {
                            if(cardSelected)
                            {
                                cardSelected.transform.localScale = Vector3.one;
                                cardSelected = null;
                            }
                            else
                            {
                                cardSelected = card;
                                cardSelected.transform.localScale *= 1.1f;
                            }   
                        }
                    }
                    else
                    {
                        PlaceCardGround placeCardGround = raycastHit.transform.gameObject.GetComponent<PlaceCardGround>();
                        
                        if(placeCardGround)
                        {                 
                            if(placeCardGround.board.name == name && cardSelected)
                            {
                                hand.cards.Remove(cardSelected);
                                ground.AppendCard(placeCardGround.index, cardSelected);
                                cardSelected = null;
                            }   
                        }
                    }
                }
            }
        }
    }

    public void PickCard()
    {
        Card card = deck.PickCardOnTop();
        hand.AppendCard(card);
    }
}
