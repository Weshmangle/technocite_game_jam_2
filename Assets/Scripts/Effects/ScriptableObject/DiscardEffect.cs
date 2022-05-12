using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/DiscardEffect")]
public class DiscardEffect : Effect
{
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