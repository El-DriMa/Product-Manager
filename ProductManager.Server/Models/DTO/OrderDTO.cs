using ProductManager.Server.Models.Domain;

namespace ProductManager.Server.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
