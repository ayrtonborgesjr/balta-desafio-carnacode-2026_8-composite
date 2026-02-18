using Xunit;
using MenusHierarquicos.Console.Core;
using MenusHierarquicos.Console.Services;

namespace MenusHierarquicos.Tests.Services;

public class MenuManagerTests
{
    [Fact]
    public void Add_ShouldAddMenuItem()
    {
        var manager = new MenuManager();
        var item = new MenuItem("Home", "/", "🏠");

        manager.Add(item);

        Assert.Contains(item, manager.Items);
        Assert.Single(manager.Items);
    }

    [Fact]
    public void Add_ShouldAddMenuGroup()
    {
        var manager = new MenuManager();
        var group = new MenuGroup("Produtos", "📦");

        manager.Add(group);

        Assert.Contains(group, manager.Items);
        Assert.Single(manager.Items);
    }

    [Fact]
    public void Items_ShouldBeEmpty_WhenCreated()
    {
        var manager = new MenuManager();

        Assert.Empty(manager.Items);
    }

    [Fact]
    public void GetTotalItems_ShouldReturnZero_WhenEmpty()
    {
        var manager = new MenuManager();

        Assert.Equal(0, manager.GetTotalItems());
    }

    [Fact]
    public void GetTotalItems_ShouldCountMenuItems()
    {
        var manager = new MenuManager();
        manager.Add(new MenuItem("Home", "/", "🏠"));
        manager.Add(new MenuItem("Sobre", "/sobre", "ℹ️"));

        Assert.Equal(2, manager.GetTotalItems());
    }

    [Fact]
    public void GetTotalItems_ShouldCountNestedItems()
    {
        var manager = new MenuManager();
        var group = new MenuGroup("Produtos", "📦");
        group.Add(new MenuItem("Todos", "/produtos"));
        group.Add(new MenuItem("Novo", "/produtos/novo"));
        manager.Add(group);

        Assert.Equal(2, manager.GetTotalItems());
    }

    [Fact]
    public void FindItemByUrl_ShouldReturnNull_WhenNotFound()
    {
        var manager = new MenuManager();
        manager.Add(new MenuItem("Home", "/", "🏠"));

        var result = manager.FindItemByUrl("/inexistente");

        Assert.Null(result);
    }

    [Fact]
    public void FindItemByUrl_ShouldFindDirectItem()
    {
        var manager = new MenuManager();
        var item = new MenuItem("Home", "/", "🏠");
        manager.Add(item);

        var result = manager.FindItemByUrl("/");

        Assert.Same(item, result);
    }

    [Fact]
    public void FindItemByUrl_ShouldFindNestedItem()
    {
        var manager = new MenuManager();
        var group = new MenuGroup("Produtos", "📦");
        var item = new MenuItem("Todos", "/produtos");
        group.Add(item);
        manager.Add(group);

        var result = manager.FindItemByUrl("/produtos");

        Assert.Same(item, result);
    }

    [Fact]
    public void Add_ShouldAllowMultipleComponents()
    {
        var manager = new MenuManager();
        manager.Add(new MenuItem("Home", "/", "🏠"));
        manager.Add(new MenuGroup("Produtos", "📦"));
        manager.Add(new MenuItem("Contato", "/contato", "📧"));

        Assert.Equal(3, manager.Items.Count);
    }
}