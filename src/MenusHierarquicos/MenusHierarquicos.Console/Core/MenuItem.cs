namespace MenusHierarquicos.Console.Core;

public class MenuItem : MenuComponent
{
    public string Url { get; set; }

    public MenuItem(string title, string url, string icon = "")
        : base(title, icon)
    {
        Url = url;
    }

    public override void Render(int indent = 0)
    {
        var indentation = new string(' ', indent * 2);
        var activeStatus = IsActive ? "✓" : "✗";
        System.Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
    }

    public override int CountItems() => 1;

    public override void Disable() => IsActive = false;

    public override MenuItem? FindByUrl(string url)
        => Url == url ? this : null;
}