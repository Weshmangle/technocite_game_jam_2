using System;
using System.Threading;

namespace CardGame
{
    class Program
    {
        public static Game game;
        public static long previousTime = 0;
        static void Main(string[] args)
        {
            try
            {
                game = new Game();
                game.AddObserver(new View());
                game.PrepareGame(5, 5, DeckUtils.DeckA(), DeckUtils.DeckB());

                Card card = game.GetBoard(true).PickCard();
                Console.WriteLine("Pick Card " + card.Name);
                game.GetBoard(true).PlayCard(card, game.GetBoard(true).GetGround().Emplacements()[0]);

                card = game.GetBoard(false).PickCard();
                Console.WriteLine("Pick Card " + card.Name);
                game.GetBoard(false).PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[2]);

                card = game.GetBoard(false).PickCard();
                Console.WriteLine("Pick Card " + card.Name);
                game.GetBoard(false).PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[3]);

                card = game.GetBoard(true).PickCard();
                Console.WriteLine("Pick Card " + card.Name);
                //game.PlayCard(card, game.GetBoard(false).GetGround().Emplacements()[3]);

                Thread thread = new Thread(OnUpdate);
                thread.Start();

                Thread.Sleep(5 * 1000);

                Console.WriteLine("Game is finish");
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("Error during game => " + exc.Message);
            }
        }

        public static void OnUpdate()
        {
            previousTime = previousTime - DateTime.Now.ToFileTime();
            game.UpdateCards((float)previousTime);
        }
    }

    public class View : Observer
    {
        public void Update(object args)
        {
            Console.WriteLine(args);
        }
    }

}