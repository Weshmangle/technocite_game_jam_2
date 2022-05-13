using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Attak")]
public class AttakEffect : Effect
{
    public override void Execute(Card card)
    {
        BoardPlayer opponent = GameManager.Instance.GetBoardOpponent(card);
        int index = card.boardPlayer.ground.GetIndexFromCard(card);
        index = opponent.ground.places.Length-1 - index;
        
        if(opponent.ground.places[index].card)
        {
            opponent.ground.DestroyCard(index);
        }
    }
}