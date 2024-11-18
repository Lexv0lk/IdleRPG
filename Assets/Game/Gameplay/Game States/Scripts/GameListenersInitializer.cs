using System.Collections.Generic;

namespace Game.Gameplay.GameStates
{
    public class GameListenersInitializer
    {
        public GameListenersInitializer(List<IGameStateListener> stateListeners,
            List<IGameUpdateListener> updateListeners, GameStateController gameStateController)
        {
            foreach (var listener in stateListeners)
                gameStateController.Register(listener);
            
            foreach (var listener in updateListeners)
                gameStateController.Register(listener);
        }
    }
}