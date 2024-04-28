using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAll()
    {
        return _productRepository.FindAll();
    }
}