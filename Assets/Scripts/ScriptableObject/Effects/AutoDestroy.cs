using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/AutoDestroy")]
public class AutoDestroy : EffectSO
{
    public override void Execute(UCard card)
    {
        card.StartCoroutine(Timeout(5, card));
    }
    public IEnumerator Timeout(float time, UCard card)
    {
        yield return new WaitForSeconds(time);
        
        GameManager.Instance.AddParticlesToCard(card);
        Destroy(card.gameObject, 2f);
    }
}