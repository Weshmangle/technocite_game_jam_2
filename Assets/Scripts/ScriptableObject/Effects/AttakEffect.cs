using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Attak")]
public class AttakEffect : EffectSO
{
    public model.Effect effect;
    public override void Execute(UCard card)
    {
        UBoard opponent = GameManager.Instance.GetBoardOpponent(card);
        int index = card.Board.ground.GetIndexFromCard(card);
        index = opponent.ground.emplacements.Length-1 - index;
        
        if(opponent.ground.emplacements[index].card)
        {
            card.AnimeAttak();
            opponent.ground.DestroyCard(index);
        }
    }
}