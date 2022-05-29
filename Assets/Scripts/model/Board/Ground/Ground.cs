using System.Collections.Generic;

namespace model
{    
    public class Ground : Observable
    {
        #region PUBLIC
        public Ground(int numberEmplacements, Board board)
        {
            for (var i = 0; i < numberEmplacements; i++)
            {
                emplacements.Add(new GroundEmplacement(i, board));
            }
        }

        public void AddCard(Card card, GroundEmplacement emplacement)
        {
            if(cards.Contains(card))
            {
                throw new System.Exception("Can't Add card already present in ground");
            }
            
            if(!emplacements.Contains(emplacement))
            {
                throw new System.Exception("Can't remove card with a emplacement not present in ground");
            }

            if(emplacement.card != null)
            {
                throw new System.Exception("Can't play card, this emplacement contain already a Card");
            }
            
            cards.Add(card);
            emplacements[emplacement.index].card = card;
            Notify(new {info = "Add card", source = this});
        }

        public void RemoveCard(GroundEmplacement emplacement)
        {
            if(!emplacements.Contains(emplacement))
            {
                throw new System.Exception("Can't remove card with a emplacement not present in ground");
            }
            
            cards.Remove(emplacements[emplacement.index].card);
            emplacements[emplacement.index].card = null;
            Notify(new {info = "Remove card", source = this});
        }

        public List<GroundEmplacement> Emplacements()
        {
            return new List<GroundEmplacement>(emplacements);
        }

        public List<Card> Cards()
        {
            return new List<Card>(cards);
        }
        #endregion

        #region PROTECTED
        protected List<Card> cards = new List<Card>();

        protected List<GroundEmplacement> emplacements = new List<GroundEmplacement>();
        #endregion
    }
}