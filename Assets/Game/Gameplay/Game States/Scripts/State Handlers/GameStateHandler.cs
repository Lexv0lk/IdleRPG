using System.Collections.Generic;

namespace Game.Gameplay.GameStates
{
    public abstract class GameStateHandler<TListener> : IGameStateHandler where TListener : IGameStateListener
    {
        private readonly HashSet<TListener> _listeners = new();
        
        public void Register(IGameStateListener listener)
        {
            if (listener is TListener concreteListener == false)
                return;
            
            _listeners.Add(concreteListener);
        }

        public void Remove(IGameStateListener listener)
        {
            if (listener is TListener concreteListener == false)
                return;
            
            _listeners.Remove(concreteListener);
        }

        public void Handle(GameStateModel model)
        {
            ChangeModelState(model);

            foreach (var listener in _listeners)
                HandleListener(listener);
        }

        protected abstract void ChangeModelState(GameStateModel model);
        protected abstract void HandleListener(TListener listener);
    }
}