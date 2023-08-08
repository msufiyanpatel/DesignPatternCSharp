// See https://aka.ms/new-console-template for more information
Console.WriteLine("Template Pattern Console Example \n \n");

WebPage productPage = new ProductPage();
productPage.CreatePage();

Console.WriteLine();

WebPage cartPage = new CartPage();
cartPage.CreatePage();

public abstract class WebPage
{
    private Header header = new Header();

    public void CreatePage()
    {
        header.AddHeader();
        AddNavigationMenu();
        AddContent();
        AddFooter();
    }

    
    protected abstract void AddNavigationMenu();
    protected abstract void AddContent();
    protected abstract void AddFooter();
}

public class Header
{
    public void AddHeader()
    {
        Console.WriteLine("Header: Logo, Navigation Links, User Profile, etc.");
    }
}

public class ProductPage : WebPage
{

    protected override void AddNavigationMenu()
    {
        Console.WriteLine("Product Page: Adding product navigation menu.");
    }

    protected override void AddContent()
    {
        Console.WriteLine("Product Page: Displaying product details and images.");
    }

    protected override void AddFooter()
    {
        Console.WriteLine("Product Page: Adding product footer.");
    }
}

public class CartPage : WebPage
{

    protected override void AddNavigationMenu()
    {
        Console.WriteLine("Cart Page: Adding cart navigation menu.");
    }

    protected override void AddContent()
    {
        Console.WriteLine("Cart Page: Displaying cart items and total price.");
    }

    protected override void AddFooter()
    {
        Console.WriteLine("Cart Page: Adding cart footer.");
    }
}
