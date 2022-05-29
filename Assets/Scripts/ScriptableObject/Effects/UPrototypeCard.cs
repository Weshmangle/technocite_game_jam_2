using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class UPrototypeCard : ScriptableObject
{
    public string nameCard;
    public TypeCard typeCard;
    public Sprite sprite;
    
    public EffectSO[] effects;
}