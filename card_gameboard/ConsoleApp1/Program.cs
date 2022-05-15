using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Game game = new Game();
            game.PrepareGame(5, 5, DeckUtils.DeckA(), DeckUtils.DeckB());

            Card card = game.GetBoard(true).PickCard();
            Console.WriteLine("Pick Card " + card.Name);
            game.PlayCard(card, game.GetBoard(true).GetGround().Emplacements()[0]);

            card = game.GetBoard(false).PickCard();
            Console.WriteLine("Pick Card " + card.Name);
            game.PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[2]);

            card = game.GetBoard(false).PickCard();
            Console.WriteLine("Pick Card " + card.Name);
            game.PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[3]);

            card = game.GetBoard(false).PickCard();
            Console.WriteLine("Pick Card " + card.Name);
            game.PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[3]);
        }
        catch (System.Exception exc)
        {
            Console.WriteLine("Error during game => " + exc.Message);
        }
    }
}