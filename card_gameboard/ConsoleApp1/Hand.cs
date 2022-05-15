using System.Collections.Generic;

public class Hand
{
    #region PUBLIC
    public Hand(int maxCardsHand)
    {
        this.maxCardsHand = maxCardsHand;
    }
    
    public void AddCard(Card card)
    {
        if(cards.Count >= maxCardsHand)
        {
            throw new System.Exception("Can add Card in fullhand");
        }
        else
        {
            cards.Add(card);
        }
    }

    public void RemoveCard(Card card)
    {
        if(!cards.Remove(card))
        {
            throw new System.Exception("Can't remove Card not present in Hand");
        }
    }

    public List<Card> Cards()
    {
        return new List<Card>(cards);
    }
    #endregion

    #region PROTECTED
    protected List<Card> cards = new List<Card>();
    
    protected int maxCardsHand;
    #endregion
}