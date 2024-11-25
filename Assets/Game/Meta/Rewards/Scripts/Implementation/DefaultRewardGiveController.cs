using Game.GameEngine.Resource;

namespace Game.Meta.Rewards
{
    public class DefaultRewardGiveController : IRewardVisitor
    {
        private readonly ResourcesStorage _storage;

        public DefaultRewardGiveController(ResourcesStorage storage)
        {
            _storage = storage;
        }
        
        public void Visit(ResourceReward reward)
        {
            foreach (var (type, val) in reward.Resources)
                _storage.Add(type, val);
        }
    }
}