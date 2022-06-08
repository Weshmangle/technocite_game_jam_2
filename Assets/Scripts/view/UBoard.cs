using UnityEngine;
using UnityEngine.UI;

public class UBoard : MonoBehaviour
{
    public StarterDeck starterDeck;
    public PickDeck deck;
    public model.Board board;
    public UHand hand;
    public UGround ground;
    public float currentTime = 0f;
    public UCard cardSelected;
    public string Faction;
    public GameObject canvasTextRelic;
    public TMPro.TextMeshProUGUI textRelic;
    public int countRelic;
    public InputManager inputManager;

   void Start()
   {
        foreach (var protoCard in starterDeck.cards)
        {
            UCard card = UCard.CreateCard(protoCard, deck.transform, new PropertiesUCard{board = this});
            deck.AddCard(card);
        }
       
        Faction = starterDeck.name;

        for (int index = 0; index < ground.emplacements.Length; index++)
        {
            UEmplacementCard placeCardGround = ground.emplacements[index];
            placeCardGround.board = this;
            placeCardGround.index = index;
        }
        
        deck.countDownNextCard.SetTimeOut(GameManager.Instance.datasGame.numberCardStartGame);
        deck.countDownNextCard.StartCoundtDown();
        deck.countDownNextBook.SetTimeOut(GameManager.Instance.datasGame.timeSecondsNextBook);
        deck.countDownNextBook.StartCoundtDown();

        inputManager = InputManager.Instance;
   }
    
    void Update()
    {
        if(deck.countDownNextCard.finish)
        {
            if(!hand.HandIsFull() && !deck.isEmpty())
            {
                PickCard();
            }
            deck.countDownNextCard.SetTimeOut(GameManager.Instance.datasGame.numberCardStartGame);
            deck.countDownNextCard.StartCoundtDown();
        }

        if(deck.countDownNextBook.finish)
        {
            deck.countDownNextBook.SetTimeOut(GameManager.Instance.datasGame.timeSecondsNextBook);
            deck.countDownNextBook.StartCoundtDown();
        }

        MoveCardSelected();
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
                return;
            }

            UEmplacementCard placeCardGround = raycastHit.transform.gameObject.GetComponent<UEmplacementCard>();
            
            if(placeCardGround)
            {
                PlaydCardSelected(placeCardGround);
                cardSelected.PlayCard();
                cardSelected = null;
            }
        }
    }

    public void TouchUp()
    {
        
        Vector3 localScale = cardSelected.transform.localScale;
        localScale.x = localScale.y = localScale.z = 1.0f;
        cardSelected.transform.localScale = localScale;
        cardSelected = null;
    }

    public void PlaydCardSelected(UEmplacementCard place)
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

    public UCard PickCard()
    {
        UCard card = deck.PickCardOnTop();
        hand.AppendCard(card);
        return card;
    }
}
