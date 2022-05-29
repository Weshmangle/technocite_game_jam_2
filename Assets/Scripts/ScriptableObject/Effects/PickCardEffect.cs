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
            card.boardPlayer.hand.AppendCard(card.boardPlayer.deck.PickSpecificCard(specificCard));
        }
        else
        {
            card.boardPlayer.hand.AppendCard(card.boardPlayer.deck.PickCardOnTop());
        }
    }
}