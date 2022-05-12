using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/PickCardEffect")]
public class PickCardEffect : Effect
{
    public override void Execute(Card card)
    {
        card.boardPlayer.hand.AppendCard(card.boardPlayer.deck.PickCardOnTop());
    }
}