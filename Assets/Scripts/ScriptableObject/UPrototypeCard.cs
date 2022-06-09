using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Cards/Card")]
public class UPrototypeCard : ScriptableObject
{
    public string nameCard;
    public TypeCard typeCard;
    public Sprite sprite;
    public EffectSO[] effects;

    public static List<model.PrototypeCard> ToPrototypeModel(UPrototypeCard[] cards)
    {
        List<model.PrototypeCard> protos = new List<model.PrototypeCard>();
        
        foreach (var proto in cards)
        {
            protos.Add(new model.PrototypeCard(proto.name, "", new model.EffectNothing()));
        }

        return protos;
    }

    public static List<model.PrototypeCard>[] ToListPrototypeModel(params UPrototypeCard[][] deckPrototypes)
    {
        List<List<model.PrototypeCard>> decks = new List<List<model.PrototypeCard>>();
        
        foreach (var deck in deckPrototypes)
        {
            decks.Add(ToPrototypeModel(deck));
        }

        return decks.ToArray();
    }
}