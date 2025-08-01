using System.ComponentModel.DataAnnotations;

namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string PESEL { get; set; }
		[Required]
		public string Position { get; set; }          // stanowisko
		[Required]
		public decimal HourlyRateGross { get; set; }             // stawka brutto
        public List<WorkLogDto> WorkLogs { get; set; } = new();     // wiązanie 1 Employee => wiele WorkItems
	}
}
