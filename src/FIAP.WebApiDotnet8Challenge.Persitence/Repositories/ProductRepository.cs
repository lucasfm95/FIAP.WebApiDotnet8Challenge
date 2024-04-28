using FIAP.WebApiDotnet8Challenge.Application.ProductUseCase;
using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new()
        {
            Brand = "Logitech",
            Code = "M325",
            Description = "Mouse wireless"
        },

        new()
        {
            Brand = "Logitech",
            Code = "K120",
            Description = "keyboard USB"
        },

        new()
        {
            Brand = "Samsung",
            Code = "S22",
            Description = "Monitor 22'"
        }
    ];
    
    public List<Product> FindAll()
    {
        return _products;
    }

    public Product Add(Product product)
    {
        _products.Add(product);
        return product;
    }

    public bool Update(Product product)
    {
        var productIndex = _products.FindIndex(pdt => pdt.Code?.Equals(pdt.Code, StringComparison.InvariantCultureIgnoreCase) ?? false);
        if (productIndex == -1)
        {
            return false;
        }

        _products[productIndex] = product;
        return true;
    }

    public bool Delete(string code)
    {
        var productIndex = _products.FindIndex(pdt => pdt.Code?.Equals(code, StringComparison.InvariantCultureIgnoreCase) ?? false);
        if (productIndex == -1)
        {
            return false;
        }

        _products.RemoveAt(productIndex);
        return true;
    }
}