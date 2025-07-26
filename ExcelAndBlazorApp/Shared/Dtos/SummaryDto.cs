namespace ExcelAndBlazorApp.Shared.Dtos
{
    public class SummaryDto
    {
        public string? YearMonth { get; set; }
        public decimal? EmployeesExpenses { get; set; }
        public decimal? OrdersExpenses { get; set; }
        public decimal? CompanyIncomes { get; set; }
        public decimal? ProfitBrutto { get; set; }
        public decimal? ProfitNetto { get; set; }
    }
}
