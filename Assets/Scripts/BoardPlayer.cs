using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlayer : MonoBehaviour
{
    public PickDeck deck;
    public StarterDeck starterDeck;
    public Hand hand;
    public Ground ground;
    public float currentTime = 0f;

    public Card cardSelected;
    
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
