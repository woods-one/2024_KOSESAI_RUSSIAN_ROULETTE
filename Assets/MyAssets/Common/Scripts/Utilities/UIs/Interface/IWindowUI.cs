public interface IWindowUI
{
    public bool IsAnimation { get; }

    public void Initialize();
    
    public void Show();
    
    public void Hide();
}
