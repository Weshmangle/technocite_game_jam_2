using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class PrototypeCard : ScriptableObject
{
    public string nameCard;
    
    public Effect[] effects;
}