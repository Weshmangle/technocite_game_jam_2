using System.Collections.Generic;

public class DeckUtils
{
    public static List<PrototypeCard> DeckA()
    {
        List<PrototypeCard> cards = new List<PrototypeCard>();

        cards.Add(new PrototypeCard("Fanatic", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Fanatic", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Acolyte", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Acolyte", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Acolyte", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Exalté", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Incanteur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Incanteur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Flétrisseur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Flétrisseur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Astrologue", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Astrologue", "", new EffectNothing()));

        return cards;
    }

    public static List<PrototypeCard> DeckB()
    {
        List<PrototypeCard> cards = new List<PrototypeCard>();

        cards.Add(new PrototypeCard("Savant", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Savant", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Psychiatre", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Psychiatre", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Chasseur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Sapeur", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Survivant", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Survivant", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Medium", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Rebouteuse", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Relic Flute", "", new EffectNothing()));
        cards.Add(new PrototypeCard("Relic Flute", "", new EffectNothing()));

        return cards;
    }
}