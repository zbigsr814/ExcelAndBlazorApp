using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }        // wiązanie 1 Order => wiele OrderItems
        public Order Order { get; set; }        // wiązanie 1 Order => wiele OrderItems

        public string ItemName { get; set; }
        public decimal PriceGross { get; set; }
        public int Quantity { get; set; }
    }
}
