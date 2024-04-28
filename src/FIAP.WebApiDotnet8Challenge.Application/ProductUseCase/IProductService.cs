using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;

public interface IProductService
{
    public List<Product> GetAll();
}