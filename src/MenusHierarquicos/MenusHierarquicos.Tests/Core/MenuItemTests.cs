using Xunit;
using MenusHierarquicos.Console.Core;

namespace MenusHierarquicos.Tests.Core;

public class MenuItemTests
{
    [Fact]
    public void MenuItem_Should_Have_Correct_Properties()
    {
        var title = "Home";
        var url = "/";
        var icon = "🏠";

        var menuItem = new MenuItem(title, url, icon);

        Assert.Equal(title, menuItem.Title);
        Assert.Equal(url, menuItem.Url);
        Assert.Equal(icon, menuItem.Icon);
    }

    [Fact]
    public void MenuItem_ShouldBeActive_ByDefault()
    {
        var menuItem = new MenuItem("Home", "/", "🏠");

        Assert.True(menuItem.IsActive);
    }

    [Fact]
    public void Disable_ShouldSetIsActiveToFalse()
    {
        var menuItem = new MenuItem("Home", "/", "🏠");

        menuItem.Disable();

        Assert.False(menuItem.IsActive);
    }

    [Fact]
    public void CountItems_ShouldReturnOne()
    {
        var menuItem = new MenuItem("Home", "/", "🏠");

        Assert.Equal(1, menuItem.CountItems());
    }

    [Fact]
    public void FindByUrl_ShouldReturnSelf_WhenUrlMatches()
    {
        var menuItem = new MenuItem("Home", "/", "🏠");

        var result = menuItem.FindByUrl("/");

        Assert.Same(menuItem, result);
    }

    [Fact]
    public void FindByUrl_ShouldReturnNull_WhenUrlDoesNotMatch()
    {
        var menuItem = new MenuItem("Home", "/", "🏠");

        var result = menuItem.FindByUrl("/sobre");

        Assert.Null(result);
    }
}