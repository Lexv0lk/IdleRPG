using System;
using System.Collections.Generic;

namespace Game.Configs
{
    public class ConfigService
    {
        private readonly Dictionary<Type, object> _configs = new();
        
        public void AddConfig<T>(T config) where T : IConfig
        {
            _configs[config.GetType()] = config;
        }

        public void RemoveConfig<T>() where T : IConfig
        {
            var type = typeof(T);

            if (_configs.ContainsKey(type))
                _configs.Remove(type);
        }
        
        public T GetConfig<T>() where T : IConfig
        {
            var type = typeof(T);
            return (T)_configs[type];
        }
    }
}