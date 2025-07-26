namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }        // wiązanie 1 Order => wiele OrderItems
        public OrderDto Order { get; set; }        // wiązanie 1 Order => wiele OrderItems

        public string ItemName { get; set; }
        public decimal PriceGross { get; set; }
        public int Quantity { get; set; }
    }
}
