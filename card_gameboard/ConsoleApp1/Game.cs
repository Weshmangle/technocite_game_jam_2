using System;
using System.Collections.Generic;

public class Game
{
    public List<Board> boards = new List<Board>();

    public void PrepareGame(int maxCardsHand, int countEmplacementGround = 5, params List<PrototypeCard>[] decks)
    {
        if(boards.Count != 0)
        {
            throw new System.Exception("Game is Already prepare");
        }
        
        for (int index = 0; index < decks.Length; index++)
        {
            Board board = new Board(maxCardsHand, countEmplacementGround);
            boards.Add(board);
            List<Card> cards = new List<Card>();

            foreach (var prototype in decks[index])
            {
                cards.Add(new Card(prototype));
            }
            board.GetDeck().FillDeck(cards.ToArray());
        }
    }

    public void PlayCard(Card card, GroundEmplacement emplacement)
    {
        emplacement.board.PlayCard(card, emplacement);
        
        foreach (var effect in card.Prototype.effects)
        {
            foreach (var interaction in effect.interactions)
            {
                switch (interaction.type)
                {
                    case TypeInteractionsBoard.ADD_GROUND:
                        ExecuteInterractionAddGround(interaction, emplacement);
                        break;
                    
                    case TypeInteractionsBoard.REMOVE_GROUND:
                        ExecuteInterractionRemoveGround(interaction, emplacement);
                        break;

                    case TypeInteractionsBoard.SPECIFIC_PICK_DECK:
                        ExecuteInterractionPickDeck(interaction, card);
                        break;

                    case TypeInteractionsBoard.RANDOM_PICK_DECK:
                        ExecuteInterractionRemoveGround(interaction, emplacement);
                        break;
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

    private void ExecuteInterractionPickDeck(InteractionsBoard interaction, Card prototypeCard)
    {
        throw new NotImplementedException();
    }

    private void ExecuteInterractionAddGround(InteractionsBoard interaction, GroundEmplacement emplacement)
    {
        GetBoard(interaction.self).GetGround().AddCard(emplacement.card, emplacement);
    }
    
    private void ExecuteInterractionRemoveGround(InteractionsBoard interaction, GroundEmplacement emplacement)
    {
        GetBoard(interaction.self).GetGround().RemoveCard(emplacement.card, emplacement);
    }

    private void ExecuteInterractionPickRandomDeck(InteractionsBoard interaction)
    {
        Board board = GetBoard(interaction.self);
        Card card = board.GetDeck().PickRandomCard();
        board.GetHand().AddCard(card);
    }
}

public class InteractionsBoard
{
    public TypeInteractionsBoard type;
    public bool self;
}

public class GroundEmplacement
{
    public int index; 
    public Card card;
    public Board board;

    public GroundEmplacement(int index, Board board)
    {
        this.board = board;
        this.index = index;
    }
}