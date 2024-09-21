using E_commerceProductCatalogAPI.Models;

namespace E_commerceProductCatalogAPI.Interfaces
{
    public interface IProductVariantRepository
    {
        ICollection<ProductVariant> GetProductVariants();
        ProductVariant GetProductVariant(int id);
        ICollection<ProductVariant> GetProductVariantsByProduct(int productId);
        bool ProductVariantExists(int id);
        bool CreateProductVariant(int productId, ProductVariant productVariant);
        bool UpdateProductVariant(ProductVariant productVariant);
        bool DeleteProductVariant(ProductVariant productVariant);
        bool Save();
    }
}