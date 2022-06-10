namespace model
{
    public interface Observer
    {
        public void UpdateSuccess(object args);
        public void UpdateError(object args);
    }
}