using Contracts;

namespace Application.Extensions;

public static class ProductExtension
{
    public static bool HasPhysicalProduct(this List<Product> product)
    {
        if (product.Any(x => x.ProductType == ProductType.Book))
            return true;
        return false;
    }
}