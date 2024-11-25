namespace Game.Meta.Rewards
{
    public interface IRewardVisitor
    {
        void Visit(ResourceReward reward);
    }
}