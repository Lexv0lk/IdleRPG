using Game.Configs;
using Game.GameEngine.LocationServices;
using UnityEngine;
using Zenject;

namespace GameEngine.DI
{
    [CreateAssetMenu(fileName = "Configs Installer", menuName = "Installers/Configs")]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ConfigsList _configsList;
        
        public override void InstallBindings()
        {
            ConfigService configService = new ConfigService();

            foreach (var config in _configsList.Configs)
                configService.AddConfig(config);

            Container.Bind<ConfigService>().FromInstance(configService).AsSingle();
        }
    }
}