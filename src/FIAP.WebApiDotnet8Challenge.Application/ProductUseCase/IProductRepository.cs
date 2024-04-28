using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;

public interface IProductRepository
{
    public List<Product> FindAll();
    public Product Add(Product product);
    public bool Update(Product product);
    public bool Delete(string code);
}