using System.Collections.Generic;

namespace Game.Gameplay.GameStates
{
    public abstract class GameUpdateHandler<TListener> : IGameUpdateHandler where TListener : IGameUpdateListener
    {
        private readonly HashSet<TListener> _listeners = new();
        
        public void Register(IGameUpdateListener listener)
        {
            if (listener is TListener concreteListener == false)
                return;
            
            _listeners.Add(concreteListener);
        }

        public void Remove(IGameUpdateListener listener)
        {
            if (listener is TListener concreteListener == false)
                return;
            
            _listeners.Remove(concreteListener);
        }

        public void Handle(float deltaTime)
        {
            foreach (var listener in _listeners)
                HandleListener(listener, deltaTime);
        }

        protected abstract void HandleListener(TListener listener, float deltaTime);
    }
}