public struct PrototypeCard
{
    public string name;
    public string description;
    public Effect[] effects;

    public PrototypeCard(string name, string description, Effect[] effects)
    {
        this.name = name;
        this.description = description;
        this.effects = effects;
    }
}