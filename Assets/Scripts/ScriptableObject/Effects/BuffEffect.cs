using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/BuffEffect")]
public class BuffEffect : EffectSO
{
    public float value;
    public bool ownCards;
    public TypeBuff type;
    
    public override void Execute(UCard card)
    {
        if(card.Board == GameManager.Instance.boardPlayerA)
        {
            //GameManager.Instance.boardPlayerB.hand.remove()
        }
        else
        {
            //GameManager.Instance.boardPlayerA.hand.remove()
        }
    }
}