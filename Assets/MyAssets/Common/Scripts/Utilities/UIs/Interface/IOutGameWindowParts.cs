namespace Roulette.Utility.UI.Interface
{
    public interface IOutGameWindowParts
    {
        public bool IsSelected { get; }

        public bool IsDisabled { get; }

        void Initialize();

        public void Show();

        public void Hide();

        public void SetSelected(bool isSelected);

        public void SetDisabled(bool isDisabled);
    }
}