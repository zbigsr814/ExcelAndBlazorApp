using ExcelAndBlazorApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Text;
using ExcelAndBlazorApp.Services;
using ExcelAndBlazorApp.Shared.Dtos;
using ExcelAndBlazorApp.Dtos;

namespace ExcelAndBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SummaryController : Controller
    {
        private readonly CompanyDbContext _dbContext;

        public SummaryController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummaryDto>>> GetSummary()
        {
            var sql = System.IO.File.ReadAllText("wwwroot/sql/ExcelGetSummaryCte.sql");

            var summary = _dbContext.summares
                .FromSqlRaw(sql)
                .AsEnumerable()
                .Select(s => new SummaryDto()
                {
                    YearMonth = s.YearMonth,
                    EmployeesExpenses = s.EmployeesExpenses,
                    OrdersExpenses = s.OrdersExpenses,
                    CompanyIncomes = s.CompanyIncomes,
                    ProfitBrutto = s.ProfitBrutto,
                    ProfitNetto = s.ProfitNetto
                })
                .ToList();

            return Ok(summary);
        }

        // [Obsolete]
        [HttpGet("excel")]
        public async Task<ActionResult> DownloadExcel()
        {
            var sql = System.IO.File.ReadAllText("wwwroot/sql/ExcelGetSummaryCte.sql");

            var summary = _dbContext.summares
                .FromSqlRaw(sql)
                .AsEnumerable()
                .ToList();

            var bytesFile = ExcelBuilder.GetExcel(summary);

            var fileName = "Report.xlsx";       // nazwa pliku jaką zobaczy user
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";  // info o typie pliku dla przeglądarki

            // Zwróć plik do pobrania
            return File(bytesFile, contentType, fileName);
        }
    }
}
