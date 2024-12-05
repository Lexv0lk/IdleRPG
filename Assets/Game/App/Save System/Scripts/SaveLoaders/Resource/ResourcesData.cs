using System;
using System.Collections.Generic;
using Game.GameEngine.Resource;

namespace Game.App.SaveSystem.Resource
{
    [Serializable]
    public struct ResourcesData
    {
        public Dictionary<ResourceType, int> Resources;
    }
}