using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Effect")]
public class EffectSO : ScriptableObject
{
    public virtual void Execute(UCard card)
    {
        throw new System.Exception("EFFECT NOT IMPLEENT");
    }
}