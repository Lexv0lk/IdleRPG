using System.Linq;
using Game.Meta.Upgrades;

namespace Game.App.SaveSystem
{
    public class UpgradesSaveLoader : SaveLoader<UpgradesSave, UpgradesManager>
    {
        protected override UpgradesSave GetSaveData(UpgradesManager service)
        {
            var upgrades = service.GetAllUpgrades();
            
            return new UpgradesSave
            {
                UpgradeStates = upgrades.Select(u => new UpgradeState { Id = u.Id, Level = u.CurrentLevel }).ToArray()
            };
        }

        protected override void SetSaveData(UpgradesManager service, UpgradesSave data)
        {
            foreach (var upgradeState in data.UpgradeStates)
                service.GetUpgrade(upgradeState.Id).SetupLevel(upgradeState.Level);
        }

        protected override void SetDefaultData(UpgradesManager service)
        {
            foreach (var upgrade in service.GetAllUpgrades())
                upgrade.SetupLevel(1);
        }
    }
}