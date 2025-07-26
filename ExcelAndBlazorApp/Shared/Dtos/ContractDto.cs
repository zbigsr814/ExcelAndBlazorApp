namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal RevenueGross { get; set; }

        public decimal RevenueNet { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
