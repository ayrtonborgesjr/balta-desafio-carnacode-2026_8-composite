using Xunit;
using MenusHierarquicos.Console.Core;

namespace MenusHierarquicos.Tests.Core;

public class MenuGroupTests
{
    [Fact]
    public void Add_ShouldAddMenuItem()
    {
        var group = new MenuGroup("Produtos", "📦");
        var item = new MenuItem("Todos", "/produtos");

        group.Add(item);

        Assert.Contains(item, group.Items);
        Assert.Single(group.Items);
    }

    [Fact]
    public void Add_ShouldAddMenuGroup()
    {
        var products = new MenuGroup("Produtos", "📦");
        var roupas = new MenuGroup("Roupas", "👕");

        products.Add(roupas);

        Assert.Contains(roupas, products.Items);
        Assert.Single(products.Items);
    }

    [Fact]
    public void Items_ShouldBeEmpty_WhenCreated()
    {
        var group = new MenuGroup("Produtos", "📦");

        Assert.Empty(group.Items);
    }

    [Fact]
    public void Remove_ShouldRemoveMenuItem()
    {
        var group = new MenuGroup("Produtos", "📦");
        var item = new MenuItem("Todos", "/produtos");
        group.Add(item);

        group.Remove(item);

        Assert.DoesNotContain(item, group.Items);
        Assert.Empty(group.Items);
    }

    [Fact]
    public void Remove_ShouldRemoveMenuGroup()
    {
        var products = new MenuGroup("Produtos", "📦");
        var roupas = new MenuGroup("Roupas", "👕");
        products.Add(roupas);

        products.Remove(roupas);

        Assert.DoesNotContain(roupas, products.Items);
        Assert.Empty(products.Items);
    }

    [Fact]
    public void CountItems_ShouldReturnZero_WhenEmpty()
    {
        var group = new MenuGroup("Produtos", "📦");

        Assert.Equal(0, group.CountItems());
    }

    [Fact]
    public void CountItems_ShouldCountDirectItems()
    {
        var group = new MenuGroup("Produtos", "📦");
        group.Add(new MenuItem("Todos", "/produtos"));
        group.Add(new MenuItem("Novo", "/produtos/novo"));

        Assert.Equal(2, group.CountItems());
    }

    [Fact]
    public void CountItems_ShouldCountNestedItems()
    {
        var products = new MenuGroup("Produtos", "📦");
        var roupas = new MenuGroup("Roupas", "👕");
        roupas.Add(new MenuItem("Camisetas", "/roupas/camisetas"));
        roupas.Add(new MenuItem("Calças", "/roupas/calcas"));
        products.Add(roupas);
        products.Add(new MenuItem("Todos", "/produtos"));

        Assert.Equal(3, products.CountItems());
    }

    [Fact]
    public void Disable_ShouldDisableGroup()
    {
        var group = new MenuGroup("Produtos", "📦");

        group.Disable();

        Assert.False(group.IsActive);
    }

    [Fact]
    public void Disable_ShouldDisableAllChildren()
    {
        var group = new MenuGroup("Produtos", "📦");
        var item1 = new MenuItem("Todos", "/produtos");
        var item2 = new MenuItem("Novo", "/produtos/novo");
        group.Add(item1);
        group.Add(item2);

        group.Disable();

        Assert.False(item1.IsActive);
        Assert.False(item2.IsActive);
    }

    [Fact]
    public void FindByUrl_ShouldReturnNull_WhenNotFound()
    {
        var group = new MenuGroup("Produtos", "📦");
        group.Add(new MenuItem("Todos", "/produtos"));

        var result = group.FindByUrl("/inexistente");

        Assert.Null(result);
    }

    [Fact]
    public void FindByUrl_ShouldFindDirectItem()
    {
        var group = new MenuGroup("Produtos", "📦");
        var item = new MenuItem("Todos", "/produtos");
        group.Add(item);

        var result = group.FindByUrl("/produtos");

        Assert.Same(item, result);
    }

    [Fact]
    public void FindByUrl_ShouldFindNestedItem()
    {
        var products = new MenuGroup("Produtos", "📦");
        var roupas = new MenuGroup("Roupas", "👕");
        var item = new MenuItem("Camisetas", "/roupas/camisetas");
        roupas.Add(item);
        products.Add(roupas);

        var result = products.FindByUrl("/roupas/camisetas");

        Assert.Same(item, result);
    }
}