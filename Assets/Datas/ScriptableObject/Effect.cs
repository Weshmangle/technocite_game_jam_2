using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Effect")]
public class Effect : ScriptableObject
{
    public virtual void Execute(Card card)
    {
        throw new System.Exception("EFFECT NOT IMPLEENT");
    }
}