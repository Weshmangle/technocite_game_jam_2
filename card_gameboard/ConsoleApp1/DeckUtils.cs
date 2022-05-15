using System.Collections.Generic;

public class DeckUtils
{
    public static List<PrototypeCard> DeckA()
    {
        List<PrototypeCard> cards = new List<PrototypeCard>();

        cards.Add(new PrototypeCard("Fanatic", "", new Effect[0]));
        cards.Add(new PrototypeCard("Fanatic", "", new Effect[0]));
        cards.Add(new PrototypeCard("Acolyte", "", new Effect[0]));
        cards.Add(new PrototypeCard("Acolyte", "", new Effect[0]));
        cards.Add(new PrototypeCard("Acolyte", "", new Effect[0]));
        cards.Add(new PrototypeCard("Exalté", "", new Effect[0]));
        cards.Add(new PrototypeCard("Incanteur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Incanteur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Flétrisseur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Flétrisseur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Astrologue", "", new Effect[0]));
        cards.Add(new PrototypeCard("Astrologue", "", new Effect[0]));

        return cards;
    }

    public static List<PrototypeCard> DeckB()
    {
        List<PrototypeCard> cards = new List<PrototypeCard>();

        cards.Add(new PrototypeCard("Savant", "", new Effect[0]));
        cards.Add(new PrototypeCard("Savant", "", new Effect[0]));
        cards.Add(new PrototypeCard("Psychiatre", "", new Effect[0]));
        cards.Add(new PrototypeCard("Psychiatre", "", new Effect[0]));
        cards.Add(new PrototypeCard("Chasseur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Sapeur", "", new Effect[0]));
        cards.Add(new PrototypeCard("Survivant", "", new Effect[0]));
        cards.Add(new PrototypeCard("Survivant", "", new Effect[0]));
        cards.Add(new PrototypeCard("Medium", "", new Effect[0]));
        cards.Add(new PrototypeCard("Rebouteuse", "", new Effect[0]));
        cards.Add(new PrototypeCard("Relic Flute", "", new Effect[0]));
        cards.Add(new PrototypeCard("Relic Flute", "", new Effect[0]));

        return cards;
    }
}