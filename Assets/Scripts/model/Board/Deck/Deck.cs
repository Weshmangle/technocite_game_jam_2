using System.Collections.Generic;
using System;

namespace model
{    
    public class Deck
    {
        #region PUBLIC
        public void FillDeck(Card[] cards)
        {
            this.cards.AddRange(cards);
        }
        
        public void SuffleDeck()
        {
            Random random = new Random();

            throw new Exception("Test THIS SUFFLE");
            
            /*foreach (var card in cards)
            {
                cards.Sort((Card a, Card b) => random.Next(-1,2));
            }
            //      or
            for (var index = 0; index < cards.Count; index++)
            {
                int randomIndex = random.Next(0, cards.Count);
                Card card = cards[index];
                Card randomCard = cards[randomIndex];
                cards.Insert(index, randomCard);
                cards.Insert(randomIndex + 1, card);
            }*/
        }
        
        public Card PickCardOnTop()
        {
            return PickCardAt(IndexTop);
        }
        
        public Card PickRandomCard()
        {
            return PickCardAt(new Random().Next(0, cards.Count));
        }
        
        public Card PickSpecificCard(Card card)
        {
            foreach (var currentCard in cards)
            {
                if(currentCard.Name == card.Name)
                {
                    return currentCard;
                }
            }
            
            return null;
        }
        #endregion

        #region PROTECTED
        protected List<Card> cards = new List<Card>();
        
        protected int IndexTop
        {
            get { return cards.Count - 1; }
        }

        protected Card GetCard(int index)
        {
            if(cards.Count == 0)
            {
                throw new System.Exception("Deck is empty, you can't pick a CARD");
            }
            else if(index < 0 || index > cards.Count)
            {
                throw new System.Exception("Can't pick à Card Index in deck is out off bound");
            }

            return cards[index];
        }

        protected Card PickCardAt(int index)
        {
            Card card = GetCard(index);
            cards.RemoveAt(index);
            return card;
        }
        #endregion
    }
}