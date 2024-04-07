namespace FIAP.WebApiDotnet8Challenge.Domain.Request;

public class ProductPostRequest
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public Decimal Price { get; set; }
}