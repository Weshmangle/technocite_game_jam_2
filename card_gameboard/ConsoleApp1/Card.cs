public class Card
{
    protected readonly PrototypeCard prototype;


    public Card(PrototypeCard prototype)
    {
        this.prototype = prototype;
    }
    public string Name
    {
        get
        {
            return prototype.name;
        }
    }

    public PrototypeCard Prototype
    {
        get
        {
            return prototype;
        }
    }
}