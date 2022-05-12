using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/BuffEffect")]
public class BuffEffect : Effect
{
    public float value;
    public bool ownCards;
    
    public override void Execute(Card card)
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