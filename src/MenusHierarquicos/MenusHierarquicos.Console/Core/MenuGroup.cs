namespace MenusHierarquicos.Console.Core;

public class MenuGroup : MenuComponent
{
    private readonly List<MenuComponent> _children = new();

    public IReadOnlyList<MenuComponent> Items => _children.AsReadOnly();

    public MenuGroup(string title, string icon = "")
        : base(title, icon)
    {
    }

    public override void Add(MenuComponent component)
        => _children.Add(component);

    public override void Remove(MenuComponent component)
        => _children.Remove(component);

    public override void Render(int indent = 0)
    {
        var indentation = new string(' ', indent * 2);
        var activeStatus = IsActive ? "✓" : "✗";
        System.Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

        foreach (var child in _children)
            child.Render(indent + 1);
    }

    public override int CountItems()
    {
        int total = 0;
        foreach (var child in _children)
            total += child.CountItems();

        return total;
    }

    public override void Disable()
    {
        IsActive = false;
        foreach (var child in _children)
            child.Disable();
    }

    public override MenuItem? FindByUrl(string url)
    {
        foreach (var child in _children)
        {
            var found = child.FindByUrl(url);
            if (found != null)
                return found;
        }

        return null;
    }
}