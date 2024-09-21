namespace E_commerceProductCatalogAPI.DTO
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal PriceModifier { get; set; }
        public int StockQuantity { get; set; }
        public int ProductId { get; set; }
    }
}