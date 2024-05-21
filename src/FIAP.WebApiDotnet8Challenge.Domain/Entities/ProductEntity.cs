namespace FIAP.WebApiDotnet8Challenge.Domain.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; } 
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}