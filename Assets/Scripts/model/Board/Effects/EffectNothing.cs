namespace model
{ 
    class EffectNothing : Effect
    {
        public override bool IsComplete()
        {
            return true;
        }

        public override void Progress(float step, Card card, object args = null)
        {
        }
    }
}