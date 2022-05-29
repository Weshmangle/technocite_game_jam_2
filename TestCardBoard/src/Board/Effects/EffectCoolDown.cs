public class EffectCoolDown : Effect
{
    protected float currentTime = 0;
    protected float maxTime = 0;

    public override void Progress(float step, Card card, object args = null)
    {
        currentTime += step;
    }
    
    public override bool IsComplete()
    {
        return currentTime >= maxTime;
    }
    
}