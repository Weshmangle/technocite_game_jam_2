using System.Collections.Generic;
public class Board
{
    #region PUBLIC

    public Board(int maxCardHand, int numberEmplacementsGround)
    {
        ground = new Ground(numberEmplacementsGround, this);
        hand = new Hand(maxCardHand);
    }

    public void PlayCard(Card card, GroundEmplacement emplacement)
    {
        hand.RemoveCard(card);
        ground.AddCard(card, emplacement);
    }

    public Card PickCard()
    {
        Card card = deck.PickCardOnTop();
        hand.AddCard(card);
        return card;
    }

    public Card PickRandomCard()
    {
        Card card = deck.PickRandomCard();
        hand.AddCard(card);
        return card;
    }

    public Card PickSpecificCard(Card prototypeCard)
    {
        Card card = deck.PickSpecificCard(prototypeCard);
        hand.AddCard(card);
        return card;
    }

    public void SuffleDeck()
    {
        deck.SuffleDeck();
    }

    public List<Card> GetCardsInHand()
    {
        return hand.Cards();
    }
    
    public List<Card> GetCardsOnGround()
    {
        return ground.Cards();
    }

    public Hand GetHand()
    {
        return hand;
    }

    public Ground GetGround()
    {
        return ground;
    }

    public Deck GetDeck()
    {
        return deck;
    }

    #endregion

    #region PROTECTED
    protected Hand hand;
    protected Ground ground;
    protected Deck deck = new Deck();
    #endregion
}