using R3;

namespace Roulette.Utility.Inputs
{
    /// <summary>
    /// アウトゲームの入力インターフェース
    /// </summary>
    public interface IGameInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> RightButton { get; }
        ReadOnlyReactiveProperty<bool> LeftButton { get; }
        ReadOnlyReactiveProperty<bool> UpButton { get; }
        ReadOnlyReactiveProperty<bool> DownButton { get; }
        ReadOnlyReactiveProperty<bool> CancelButton { get; }
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
    }
}