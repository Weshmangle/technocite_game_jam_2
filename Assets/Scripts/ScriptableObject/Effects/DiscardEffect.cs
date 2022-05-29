using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/DiscardEffect")]
public class DiscardEffect : EffectSO
{
    public bool OwnCards;
    
    public override void Execute(UCard card)
    {
        if(card.boardPlayer == GameManager.Instance.boardPlayerA)
        {
            //GameManager.Instance.boardPlayerB.hand.remove()
        }
        else
        {
            //GameManager.Instance.boardPlayerA.hand.remove()
        }
    }
}