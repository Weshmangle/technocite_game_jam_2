using UnityEngine;

[CreateAssetMenu(menuName = "Empty Deck")]
public class StarterDeck : ScriptableObject
{
    public PrototypeCard[] cards;
    public string faction;
}