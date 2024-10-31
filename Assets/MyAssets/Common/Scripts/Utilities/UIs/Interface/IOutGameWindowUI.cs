using Roulette.OutGame;

public interface IOutGameWindowUI
{
    public bool IsAnimation { get; }

    public void Initialize(OutGameWindowInfo outGameWindowInfo);
    
    public void Show();
    
    public void Hide();
}
