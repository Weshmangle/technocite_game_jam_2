using UnityEngine;

[CreateAssetMenu(menuName = "Empty Deck")]
public class StarterDeck : ScriptableObject
{
    public UPrototypeCard[] cards;
    public string faction;
}