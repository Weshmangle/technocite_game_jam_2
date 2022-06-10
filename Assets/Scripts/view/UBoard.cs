using System;
using UnityEngine;
using UnityEngine.UI;

public class UBoard : MonoBehaviour, model.Observer
{
    public StarterDeck starterDeck;
    public PickDeck deck;
    public model.Board board;
    public UHand uHand;
    public UGround ground;
    public UCard cardSelected;

   public void Init(model.Board board)
   {
       this.board = board;
       this.uHand.SetHand(board.GetHand());
       for (int index = 0; index < board.GetDeck().Cards.Count; index++)
       {
            model.Card card = board.GetDeck().Cards[index];
            UPrototypeCard prottype = starterDeck.cards[index];

            UCard uCard = UCard.CreateCard(prottype, deck.transform, new PropertiesUCard{board = this, card = card});
            deck.AddCard(uCard);
       }

        for (int index = 0; index < ground.emplacements.Length; index++)
        {
            UEmplacementCard placeCardGround = ground.emplacements[index];
            placeCardGround.board = this;
            placeCardGround.index = index;
        }
        
        // deck.countDownNextCard.SetTimeOut(GameManager.Instance.datasGame.numberCardStartGame);
        // deck.countDownNextCard.StartCoundtDown();
        // deck.countDownNextBook.SetTimeOut(GameManager.Instance.datasGame.timeSecondsNextBook);
        // deck.countDownNextBook.StartCoundtDown();
   }
    
    void Update()
    {
        if(GameManager.Instance.nextCardCountDown.finish)
        {
            if(!uHand.HandIsFull() && !deck.isEmpty())
            {
                PickCard(board.PickCard());
            }
            GameManager.Instance.nextCardCountDown.Start(GameManager.Instance.datasGame.numberCardStartGame);
        }

        if(GameManager.Instance.nextBookCountDown.finish)
        {
            GameManager.Instance.nextBookCountDown.Start(GameManager.Instance.datasGame.timeSecondsNextBook);
        }

        MoveCardSelected();
        EnterGroundEmplacement();
    }

    private void EnterGroundEmplacement()
    {
        if(cardSelected)
        {
            RaycastHit raycastHit;

            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.positionTouch);
            
            if(Physics.Raycast(ray, out raycastHit, 100f))
            {
                UEmplacementCard placeCardGround = raycastHit.transform.gameObject.GetComponent<UEmplacementCard>();
            
                if(placeCardGround && placeCardGround.ground)
                {
                    PlaydCardSelected(placeCardGround);
                }
            }
        }
    }

    public void MoveCardSelected()
    {
        RaycastHit raycastHit; 
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.positionTouch);        
        
        if(Physics.Raycast(ray, out raycastHit, 100f) && cardSelected)
        {
            Vector3 position = cardSelected.transform.position;
            position.x = ray.origin.x;
            position.z = ray.origin.z;
            cardSelected.transform.position = position;
        }
    }

    public void TouchDown()
    {
        RaycastHit raycastHit;

        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.positionTouch);
        
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 10);
        
        if(Physics.Raycast(ray, out raycastHit, 100f))
        {
            UCard card = raycastHit.transform.gameObject.GetComponent<UCard>();
        
            if(card)
            {
                cardSelected = card;
                Vector3 localScale = cardSelected.transform.localScale;
                localScale.x = localScale.y = localScale.z = 1.1f;
                cardSelected.transform.localScale = localScale;
            }
        }
    }

    public void TouchUp()
    {
        if(cardSelected)
        {
            Vector3 localScale = cardSelected.transform.localScale;
            localScale.x = localScale.y = localScale.z = 1.0f;
            cardSelected.transform.localScale = localScale;
            cardSelected = null;
        }
    }

    public void PlaydCardSelected(UEmplacementCard place)
    {
        board.PlayCard(cardSelected.card, board.GetGround().Emplacements()[place.index]);
        uHand.Discard(cardSelected);
        ground.AppendCard(place.index, cardSelected);
        cardSelected = null;
    }

    public void PlayRelicSelected()
    {
        /*return;
        hand.Discard(cardSelected);
        countRelic++;
        textRelic.text = $" {countRelic} / 10";
        Destroy(cardSelected.gameObject);
        cardSelected = null;*/
    }

    public UCard PickCard(model.Card card)
    {
        UCard uCard = deck.PickCardOnTop();
        uCard.card = card;
        uHand.AppendCard(uCard);
        return uCard;
    }

    public void UpdateSuccess(object args)
    {
        Debug.Log(args);
    }

    public void UpdateError(object args)
    {
        throw new NotImplementedException();
    }
}
