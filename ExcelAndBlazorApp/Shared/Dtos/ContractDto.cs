using System.ComponentModel.DataAnnotations;

namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public decimal RevenueGross { get; set; }

        [Required]
        public decimal RevenueNet { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public string StartDateFormatted => StartDate.ToString("dd/MM/yyyy");
		[Required]
        public DateTime EndDate { get; set; }
		public string EndDateFormatted => EndDate.ToString("dd/MM/yyyy");
	}

}
