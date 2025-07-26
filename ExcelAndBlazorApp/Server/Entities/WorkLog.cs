using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class WorkLog
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }                     // wiązanie 1 Employee => wiele WorkItems
        public Employee Employee { get; set; }                 // wiązanie 1 Employee => wiele WorkItems
        public DateTime Date { get; set; }                  // określenie dnia logowania pracownika
        public decimal HoursWorked { get; set; }

        public decimal CostGross => (HoursWorked * Employee.HourlyRateGross);       // automatyczne obliczenie dniówki Brutto
        public decimal CostNet => (CostGross / 1.23m);                             // automatyczne obliczenie dniówki Netto
    }

}
