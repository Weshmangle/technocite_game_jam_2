using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/AutoDestroy")]
public class AutoDestroy : Effect
{
    public override void Execute(Card card)
    {
        Debug.Log("sds");
        Destroy(card.gameObject);
    }
}