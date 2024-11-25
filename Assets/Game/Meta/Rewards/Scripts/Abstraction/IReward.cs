namespace Game.Meta.Rewards
{
    public interface IReward
    {
        void Accept(IRewardVisitor visitor);
    }
}