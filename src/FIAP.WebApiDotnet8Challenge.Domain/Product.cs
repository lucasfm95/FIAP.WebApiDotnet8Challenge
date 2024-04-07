namespace FIAP.WebApiDotnet8Challenge.Domain;

public class Product
{
    public int Id { get; private set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; } 
    public decimal Price { get; private set; }

    public Product() { }
    
    public Product(string? code, string? description, string? brand, decimal price)
    {
        Id = 0;
        Code = code;
        Description = description;
        Brand = brand;
        Price = price;
    }
}