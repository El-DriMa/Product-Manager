using ProductManager.Server.Models.Domain;

namespace ProductManager.Server.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal? UnitPrice { get; set; }

        public string? Package { get; set; }

        public bool IsDiscontinued { get; set; }
    }
}
