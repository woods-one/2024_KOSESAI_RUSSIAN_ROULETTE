using Roulette.OutGame;

namespace Roulette.Utility.UI.Interface
{
    public interface IOutGameWindowUI
    {
        public bool IsAnimation { get; }

        public void Initialize(OutGameWindowInfo outGameWindowInfo);

        public void Show();

        public void Hide();
    }
}