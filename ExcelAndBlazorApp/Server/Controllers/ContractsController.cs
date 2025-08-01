using AutoMapper;
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
		private readonly IMapper _mapper;

		public ContractsController(CompanyDbContext _dbContext, IMapper mapper)
        {
            this._dbContext = _dbContext;
			_mapper = mapper;
		}

        [HttpGet]
        public ActionResult<IEnumerable<ContractDto>> GetAll()
        {
            var contracts = _dbContext.contracts.ToList();
            var dtos = _mapper.Map<List<ContractDto>>(contracts);

			if (dtos is null)
				return NotFound();

			return dtos;
        }

        [HttpPost]
        public IActionResult Post(ContractDto contract)
        {
            var dto = _mapper.Map<Contract>(contract);

            _dbContext.contracts.Add(dto);
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
