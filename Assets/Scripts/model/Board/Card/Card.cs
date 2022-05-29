namespace model
{    
    public class Card
    {
        protected readonly PrototypeCard prototype;
        
        public Effect currentEffect;

        public GroundEmplacement emplacement;

        public Card(PrototypeCard prototype)
        {
            this.prototype = prototype;
            currentEffect = prototype.effect;
        }
        
        public void NextEffect()
        {
            currentEffect = currentEffect.NextEffect;
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
}