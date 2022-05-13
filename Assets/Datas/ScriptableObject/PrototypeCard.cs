using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class PrototypeCard : ScriptableObject
{
    public string nameCard;
    public Sprite sprite;
    
    public Effect[] effects;
}