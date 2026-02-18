using MenusHierarquicos.Console.Core;

namespace MenusHierarquicos.Console.Services;

public class MenuManager
{
    private readonly List<MenuComponent> _root = new();

    public IReadOnlyList<MenuComponent> Items => _root.AsReadOnly();

    public void Add(MenuComponent component)
        => _root.Add(component);

    public void RenderMenu()
    {
        System.Console.WriteLine("=== Menu Principal ===\n");
        foreach (var c in _root)
            c.Render();
    }

    public int GetTotalItems()
    {
        int total = 0;
        foreach (var c in _root)
            total += c.CountItems();
        return total;
    }

    public MenuItem? FindItemByUrl(string url)
    {
        foreach (var c in _root)
        {
            var found = c.FindByUrl(url);
            if (found != null)
                return found;
        }
        return null;
    }
}