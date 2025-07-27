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

        [HttpPost]
        public IActionResult Post(ContractDto contract)
        {
            _dbContext.contracts
                .Add(new Contract()
                {
                    Id = contract.Id,
                    ClientName = contract.ClientName,
                    RevenueGross = contract.RevenueGross,
                    StartDate = contract.StartDate,
                    EndDate = contract.EndDate
                });

            _dbContext.SaveChanges();
            return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var entity = _dbContext.contracts.FirstOrDefault(c => c.Id == id);

			if (entity == null)
			{
				return NotFound();
			}

			_dbContext.contracts.Remove(entity);
			_dbContext.SaveChanges();

            return Ok();
		}
	}
}
