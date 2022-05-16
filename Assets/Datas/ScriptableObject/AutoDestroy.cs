using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/AutoDestroy")]
public class AutoDestroy : Effect
{
    public override void Execute(Card card)
    {
        card.StartCoroutine(Timeout(5, card));
    }
    public IEnumerator Timeout(float time, Card card)
    {
        yield return new WaitForSeconds(time);
        
        GameManager.Instance.AddParticlesToCard(card);
        Destroy(card.gameObject, 2f);
    }
}