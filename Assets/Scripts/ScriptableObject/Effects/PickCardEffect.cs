using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/PickCardEffect")]
public class PickCardEffect : EffectSO
{
    public UPrototypeCard specificCard;
    
    public override void Execute(UCard card)
    {
        if(card)
        {
            card.Board.hand.AppendCard(card.Board.deck.PickSpecificCard(specificCard));
        }
        else
        {
            card.Board.hand.AppendCard(card.Board.deck.PickCardOnTop());
        }
    }
}