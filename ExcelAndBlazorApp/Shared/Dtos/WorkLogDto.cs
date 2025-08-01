using ExcelAndBlazorApp.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class WorkLogDto
    {
        public int Id { get; set; }
		[Required]
		public int EmployeeId { get; set; }                     // wiązanie 1 Employee => wiele WorkItems
		[Required]
		public DateTime Date { get; set; }                  // określenie dnia logowania pracownika
		public string DateFormatted => Date.ToString("dd/MM/yyyy");
		[Required]
		public decimal HoursWorked { get; set; }

		public decimal CostGross { get; set; }       // automatyczne obliczenie dniówki Brutto
		public decimal CostNet { get; set; }         // automatyczne obliczenie dniówki Netto
    }

}
