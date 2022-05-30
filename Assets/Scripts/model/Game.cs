using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Game : Observable, Observer
    {
        protected List<Board> boards = new List<Board>();
        protected Board boardWinner = null;
        protected float currentTime;
        protected float durationGame = 5 * 60;
        protected float relicCountVictory = 10;
        protected float timeNextCard = 20;
        protected float timeNextBook = 20;
        protected float cardCountStart = 3;

        public void PrepareGame(int maxCardsHand, int countEmplacementsGround, float durationGame, float timeNextCard, float timeNextBook, params List<PrototypeCard>[] decks)
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
            
            currentTime = 0;
            this.durationGame = durationGame;
            this.timeNextCard = timeNextCard;
            this.timeNextBook = timeNextBook;

            Notify(new {info = "Game prepared", source = this});
        }

        public Board GetOpponentBoard(Board board)
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
                        card.currentEffect.Progress(time, card, "");
                        Notify(new {info = "effect on progress", source = card});
                    }
                }
            }
        }

        public void IncrementTime(float time)
        {
            currentTime += time;
            boardWinner = currentTime < durationGame ? null : boards[0];
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

        public Board Winner()
        {
            return this.boardWinner;
        }

        public bool IsOver()
        {
            return boardWinner is not null;
        }

        public void Update(object args)
        {
            Notify(args);
        }
    }
}