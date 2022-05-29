namespace model
{    
    public abstract class Effect
    {
        protected string name = "";
        protected string description = "";
        protected Effect nextEffect;

        public string Name
        {
            get { return name; }
            set { name = value; } 
        }

        public string Description
        {
            get { return description; }
            set { description = value; } 
        }

        public Effect NextEffect
        {
            get { return nextEffect; }
            set { nextEffect = value; } 
        }

        public abstract void Progress(float step, Card card, object args = null);
        public abstract bool IsComplete();
    }
}