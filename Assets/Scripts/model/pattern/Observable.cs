using System.Collections.Generic;

namespace model
{    
    public class Observable
    {
        protected List<Observer> observers = new List<Observer>();

        public void Notify(object data)
        {
            foreach (var observer in observers)
            {
                observer.UpdateBoardGame(data);
            }
        }

        public void NotifyError(object data)
        {
            foreach (var observer in observers)
            {
                observer.UpdateBoardGame(data);
            }
        }

        public void AddObserver(Observer obs)
        {
            observers.Add(obs);
        }
        
        public void RemoveObserver(Observer obs)
        {
            observers.Remove(obs);
        }
    }
}