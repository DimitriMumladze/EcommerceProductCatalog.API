namespace E_commerceProductCatalogAPI.Models;

public class ProductVariant
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal PriceModifier { get; set; }
    public int StockQuantity { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
