using ProductManager.Server.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Server.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal? UnitPrice { get; set; }

        public string? Package { get; set; }

        public bool? IsDiscontinued { get; set; }

        [Range(1, 29, ErrorMessage = "SupplierId has to be between 1 and 29.")]
        public int SupplierId { get; set; }
    }
}
