using System.Collections.Generic;

namespace model
{
    public struct PrototypeCard
    {
        public string name;
        public string description;
        public Effect effect;

        public PrototypeCard(string name, string description, Effect effect)
        {
            this.name = name;
            this.description = description;
            this.effect = effect;
        }

        public static Card[] DeckPrototypeToDeckCard(List<PrototypeCard> deck)
        {
            List<Card> cards = new List<Card>();
            
            foreach (var prototype in deck)
            {
                cards.Add(new Card(prototype));
            }
            
            return cards.ToArray();
        }
    }
}