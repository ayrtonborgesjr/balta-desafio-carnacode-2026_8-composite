namespace MenusHierarquicos.Console.Core;

public abstract class MenuComponent
{
    public string Title { get; protected set; }
    public string Icon { get; protected set; }
    public bool IsActive { get; set; } = true;

    protected MenuComponent(string title, string icon = "")
    {
        Title = title;
        Icon = icon;
    }

    public abstract void Render(int indent = 0);
    public abstract int CountItems();
    public abstract void Disable();

    // Operações opcionais para composite
    public virtual void Add(MenuComponent component)
        => throw new NotSupportedException();

    public virtual void Remove(MenuComponent component)
        => throw new NotSupportedException();

    public virtual MenuItem? FindByUrl(string url)
        => null;
}