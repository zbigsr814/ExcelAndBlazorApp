using System.ComponentModel.DataAnnotations;

namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
		[Required]
		public string OrderNumber { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public string DateFormatted => Date.ToString("dd/MM/yyyy");
		public List<OrderItemDto> Items { get; set; } = new();          // wiązanie 1 Order => wiele OrderItems

		[Required]
		public decimal TotalGross { get; set; }   // suma Brutto zamuwień
		[Required]
		public decimal TotalNet { get; set; }                  // suma Netto zamówiń
    }
}
