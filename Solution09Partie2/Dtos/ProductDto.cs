namespace Solution09Partie2.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Category { get; set; }

        public decimal? Price { get; set; }

        public int? StockQuantity { get; set; }

        public string? Description { get; set; }
    }
}
