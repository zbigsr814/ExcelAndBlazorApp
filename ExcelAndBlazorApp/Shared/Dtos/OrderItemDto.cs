using System.ComponentModel.DataAnnotations;

namespace ExcelAndBlazorApp.Shared.Dtos
{
	public class OrderItemDto
	{
		public int Id { get; set; }
		public int OrderId { get; set; }        // wiązanie 1 Order => wiele OrderItems

		[Required]
		public string ItemName { get; set; }
		[Required]
		public decimal PriceGross { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
