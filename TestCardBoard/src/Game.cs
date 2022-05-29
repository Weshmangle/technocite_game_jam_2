using System;
using System.Collections.Generic;

namespace CardGame
{    
    public class Game : Observable, Observer
    {
        public List<Board> boards = new List<Board>();

        public void PrepareGame(int maxCardsHand, int countEmplacementsGround = 5, params List<PrototypeCard>[] decks)
        {
            if(boards.Count != 0)
            {
                throw new System.Exception("Game is Already prepare");
            }
            
            foreach (var deck in decks)
            {
                Board board = new Board(maxCardsHand, countEmplacementsGround);
                board.GetDeck().FillDeck(PrototypeCard.DeckPrototypeToDeckCard(deck));
                boards.Add(board);
                board.AddObserver(this);
            }
            Notify(new {info = "Game prepared", source = this});
        }

        internal Board GetOpponentBoard(Board board)
        {
            List<Board> boards1 = boards.ToList();
            boards.Remove(board);
            return boards.GetEnumerator().Current;
        }
        
        public void UpdateCards(float time)
        {
            foreach (var board in boards)
            {
                foreach (var card in board.GetGround().Cards())
                {
                    if(card.currentEffect.IsComplete())
                    {
                        card.NextEffect();
                        Notify(new {info = "Next effect", source = card});
                    }
                    else
                    {
                        card.currentEffect.Progress(time, card, this);
                        Notify(new {info = "effect on progress", source = card});
                    }
                }
            }
        }

        public Board GetBoard(bool self)
        {
            return self ? boards[0] : boards[1];
        }

        public Hand GetHand(bool self)
        {
            return GetBoard(self).GetHand();
        }

        public Deck GetDeck(bool self)
        {
            return GetBoard(self).GetDeck();
        }

        public void Update(object args)
        {
            Notify(args);
        }
    }
}