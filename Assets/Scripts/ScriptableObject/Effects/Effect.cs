using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Effect")]
public class EffectSO : ScriptableObject
{
    public string classNameEffect;
    public virtual void Execute(UCard card)
    {
        throw new System.Exception("EFFECT NOT IMPLEENT");
    }
}