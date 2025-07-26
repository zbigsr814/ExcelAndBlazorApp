namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderItemDto> Items { get; set; }          // wiązanie 1 Order => wiele OrderItems

        public decimal TotalGross { get; set; }   // suma Brutto zamówiń
        public decimal TotalNet { get; set; }                  // suma Netto zamówiń
    }
}
