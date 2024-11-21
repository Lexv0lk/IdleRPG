using UniRx;

namespace Game.Gameplay.Character
{
    public interface IHealthViewPresenter
    {
        StringReactiveProperty Health { get; }
        FloatReactiveProperty HealthPart { get; }
        BoolReactiveProperty CanShowHealth { get; }
    }
}