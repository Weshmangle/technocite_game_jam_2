using System.Collections.Generic;

namespace model
{
    public class Hand : Observable
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
                NotifyError(new {type = TypeError.HAND_IS_FULL, args = new {TypeAction.ADD_CARD_HAND}});
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
                NotifyError(new {type = TypeError.CARD_NOT_HAND, args = new {TypeAction.REMOVE_CARD_HAND}});
            }
        }

        public bool HandIsFull()
        {
            return cards.Count == model.Game.MAX_CARDS_HAND;
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
}