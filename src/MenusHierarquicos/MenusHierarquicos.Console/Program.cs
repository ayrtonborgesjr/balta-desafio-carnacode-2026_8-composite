using MenusHierarquicos.Console.Core;
using MenusHierarquicos.Console.Services;

var manager = new MenuManager();

manager.Add(new MenuItem("Home", "/", "🏠"));

var products = new MenuGroup("Produtos", "📦");
products.Add(new MenuItem("Todos", "/produtos"));
products.Add(new MenuItem("Categorias", "/categorias"));

var roupas = new MenuGroup("Roupas", "👕");
roupas.Add(new MenuItem("Camisetas", "/roupas/camisetas"));
roupas.Add(new MenuItem("Calças", "/roupas/calcas"));

products.Add(roupas);
manager.Add(products);

manager.RenderMenu();