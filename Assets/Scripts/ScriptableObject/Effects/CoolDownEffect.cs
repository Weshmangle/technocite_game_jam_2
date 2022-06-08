using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CoolDown")]
public class CoolDownEffect : EffectSO
{
    public EffectSO[] effects;

    public float cooldownValue;
    
    public float currentTime = 0f;
    
    public override void Execute(UCard card)
    {
        var cooldown = cooldownValue * GameManager.DEBUG_FACTOR;
        card.StartCoroutine(Timeout(cooldown, card));
        card.StartTimer(cooldown);
    }

    public IEnumerator Timeout(float time, UCard card)
    {
        yield return new WaitForSeconds(time);

        foreach (var effect in effects)
        {
            effect.Execute(card);
        }
        Execute(card);
    }
}