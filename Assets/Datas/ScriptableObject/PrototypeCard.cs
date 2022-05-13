using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class PrototypeCard : ScriptableObject
{
    public string nameCard;
    public TypeCard typeCard;
    public Sprite sprite;
    
    public Effect[] effects;
}