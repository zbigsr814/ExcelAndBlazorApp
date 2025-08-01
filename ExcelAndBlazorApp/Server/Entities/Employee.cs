using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PESEL { get; set; }
        public string Position { get; set; }             // stanowisko
        public decimal HourlyRateGross { get; set; }             // stawka brutto
        public ICollection<WorkLog> WorkLogs { get; set; }     // wiązanie 1 Employee => wiele WorkItems
    }
}
