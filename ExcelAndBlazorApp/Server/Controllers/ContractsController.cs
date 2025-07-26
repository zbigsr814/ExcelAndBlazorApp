using ExcelAndBlazorApp.Entities;
using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ExcelAndBlazorApp.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly CompanyDbContext _dbContext;

        public ContractsController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public IEnumerable<ContractDto> GetAll()
        {
            var contracts = _dbContext.contracts
                .Select(c => new ContractDto()
                {
                    Id = c.Id,
                    ClientName = c.ClientName,
                    RevenueGross = c.RevenueGross,
                    RevenueNet = c.RevenueNet,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                }).ToList();

            return contracts;
        }
    }
}
