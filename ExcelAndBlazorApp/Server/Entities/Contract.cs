using Microsoft.EntityFrameworkCore;

namespace ExcelAndBlazorApp.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = "";
        public decimal RevenueGross { get; set; }

        public decimal RevenueNet => RevenueGross * 1.23m;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
