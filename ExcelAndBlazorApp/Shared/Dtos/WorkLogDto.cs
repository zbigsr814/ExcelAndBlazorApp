namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class WorkLogDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }                     // wiązanie 1 Employee => wiele WorkItems
        public EmployeeDto Employee { get; set; }                 // wiązanie 1 Employee => wiele WorkItems
        public DateTime Date { get; set; }                  // określenie dnia logowania pracownika
        public decimal HoursWorked { get; set; }

        public decimal CostGross { get; set; }       // automatyczne obliczenie dniówki Brutto
        public decimal CostNet { get; set; }                             // automatyczne obliczenie dniówki Netto
    }

}
