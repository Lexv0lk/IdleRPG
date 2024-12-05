using Game.Gameplay.Resource;
using System.Linq;

namespace Game.App.SaveSystem.Resource
{
    public class ResourcesSaveLoader : SaveLoader<ResourcesData, ResourcesManager>
    {
        protected override ResourcesData GetSaveData(ResourcesManager service)
        {
            return new ResourcesData
            {
                Resources = service.GetCurrentResources()
                    .ToDictionary(x => x.Key, x => x.Value)
            };
        }

        protected override void SetSaveData(ResourcesManager service, ResourcesData data)
        {
            service.Setup(data.Resources);
        }

        protected override void SetDefaultData(ResourcesManager service)
        {
            service.Setup(service.ResourcesCatalog.InitialResources
                .ToDictionary(x => x.Key.Type, x => x.Value));
        }
    }
}