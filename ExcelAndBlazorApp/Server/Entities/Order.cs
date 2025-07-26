using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = "";
        public DateTime Date { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();          // wiązanie 1 Order => wiele OrderItems

        public decimal TotalGross => Items.Sum(i => i.PriceGross * i.Quantity);     // suma Brutto zamówiń
        public decimal TotalNet => TotalGross / 1.23m;                      // suma Netto zamówiń
    }
}
