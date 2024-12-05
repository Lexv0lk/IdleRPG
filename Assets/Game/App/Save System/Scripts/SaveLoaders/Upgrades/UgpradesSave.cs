using System;

namespace Game.App.SaveSystem
{
    [Serializable]
    public struct UpgradesSave
    {
        public UpgradeState[] UpgradeStates;
    }

    [Serializable]
    public struct UpgradeState
    {
        public string Id;
        public int Level;
    }
}