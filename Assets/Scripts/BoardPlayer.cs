using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
       foreach (var card in starterDeck.cards)
       {
            deck.AddCard(Card.CreateCard(card));
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
            if(!hand.HandIsFull())
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
                        if(cardSelected)
                        {
                            cardSelected.transform.localScale = Vector3.one;
                        }
                        cardSelected = card;
                        cardSelected.transform.localScale *= 1.1f;
                    }
                }
            }
        }
    }
}
