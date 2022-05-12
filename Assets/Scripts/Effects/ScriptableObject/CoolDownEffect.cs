using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CoolDown")]
public class CoolDownEffect : Effect
{
    public Effect[] effects;

    public float cooldownValue;
    
    public float currentTime = 0f;
    
    public override void Execute(Card card)
    {
        foreach (var effect in effects)
        {
            effect.Execute(card);
        }
    }
}