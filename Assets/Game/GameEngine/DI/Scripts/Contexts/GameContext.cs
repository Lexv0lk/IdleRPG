using System.Collections.Generic;

namespace Game.GameEngine.DI
{
    public class GameContext
    {
        private readonly ServicesContext _servicesContext;
        
        public GameContext(List<IGameService> services)
        {
            _servicesContext = new();

            foreach (var service in services)
                _servicesContext.RegisterService(service);
        }

        public void AddService<T>(T service) where T : IGameService
        {
            _servicesContext.RegisterService(service);
        }
        
        public T GetService<T>()
        {
            return _servicesContext.GetService<T>();
        } 
    }
}