using UnityEngine;
using UnityEngine.UI;

public class BoardPlayer : MonoBehaviour
{
    public PickDeck deck;
    public StarterDeck starterDeck;
    public Hand hand;
    public Ground ground;
    public float currentTime = 0f;

    public Card cardSelected;
    public string Faction;
    public GameObject canvasTextRelic;
    public Text textRelic;
    public int countRelic;

   void Start()
   {
        foreach (var protoCard in starterDeck.cards)
        {
                Card card = Card.CreateCard(protoCard, deck.transform);
                card.boardPlayer = this;
                deck.AddCard(card);
        }
       
        Faction = starterDeck.name;

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
        if(deck.countDownNextCard.finish)
        {
            if(!hand.HandIsFull() && !deck.isEmpty())
            {
                PickCard();
            }
            deck.countDownNextCard.SetTimeOut(GameManager.TIME_OUT_NEXT_CARD);
            deck.countDownNextCard.StartCoundtDown();
        }

        if(deck.countDownNextBook.finish)
        {
            deck.countDownNextBook.SetTimeOut(GameManager.TIME_OUT_NEXT_BOOK);
            deck.countDownNextBook.StartCoundtDown();
        }

        if(InputManager.Instance.clicked)
        {
            RaycastHit raycastHit;

            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.positionTouch);
            
            if(Physics.Raycast(ray, out raycastHit, 100f))
            {
                if(raycastHit.transform != null)
                {
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 10);

                    if(cardSelected)
                    {
                        Vector3 position = cardSelected.transform.position;
                        position.x = ray.origin.x;
                        position.z = ray.origin.z;
                        cardSelected.transform.position = position;
                    }
                    else
                    {
                        Card card = raycastHit.transform.gameObject.GetComponent<Card>();
                    
                        if(!cardSelected && card)
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
                                    
                                    if(card.prottotypeCard.typeCard == TypeCard.RELIC)
                                    {
                                        PlayRelicSelected();
                                    }
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
                                    PlaydCardSelected(placeCardGround);
                                    cardSelected.PlayCard();
                                    cardSelected = null;
                                }   
                            }
                        }
                    }
                }
            }
        }
    }

    public void PlaydCardSelected(PlaceCardGround place)
    {
        hand.cards.Remove(cardSelected);
        ground.AppendCard(place.index, cardSelected);
    }

    public void PlayRelicSelected()
    {
        hand.cards.Remove(cardSelected);
        countRelic++;
        textRelic.text = $" {countRelic} / 10";
        Destroy(cardSelected.gameObject);
        cardSelected = null;
    }

    public Card PickCard()
    {
        Card card = deck.PickCardOnTop();
        hand.AppendCard(card);
        return card;
    }
}
