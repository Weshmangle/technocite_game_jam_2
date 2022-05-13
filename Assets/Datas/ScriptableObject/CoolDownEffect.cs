using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CoolDown")]
public class CoolDownEffect : Effect
{
    public Effect[] effects;

    public float cooldownValue;
    
    public float currentTime = 0f;

    public CountDown countDown;
    
    public override async void Execute(Card card)
    {
        card.StartCoroutine(nameof(timeout), 10);
        card.StartTimer(cooldownValue);
    }

    public IEnumerator timeout(float time)
    {
        yield return new WaitForSeconds(time);
    }
}