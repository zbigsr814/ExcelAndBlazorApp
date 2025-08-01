using AutoMapper;
using ExcelAndBlazorApp.Entities;
using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;

namespace ExcelAndBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeesController(CompanyDbContext _dbContext, IMapper mapper)
        {
            this._dbContext = _dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = _dbContext.employees.ToList();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);

            if (dtos is null)
                return NotFound();

            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmployeeDto> GetWorkLogs([FromRoute] int Id)
        {
            var employees = _dbContext.employees
                .Include(e => e.WorkLogs)
                .Where(e => e.Id == Id)
                .FirstOrDefault();

            var dtos = _mapper.Map<EmployeeDto>(employees);

            if (dtos is null)
                return NotFound();

            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody] EmployeeDto employee)
        {
            var entity = _mapper.Map<Employee>(employee);

            _dbContext.employees.Add(entity);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult PostWorkItem([FromBody] WorkLogDto workLog)
        {
            var entity = _mapper.Map<WorkLog>(workLog);

            _dbContext.workLogs.Add(entity);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var entity = _dbContext.employees.FirstOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.employees.Remove(entity);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{employeeId}/{workLogId}")]
        public IActionResult DeleteWorkLog([FromRoute] int employeeId, [FromRoute] int workLogId)
        {
            var entity = _dbContext.workLogs
                .Where(wl => wl.EmployeeId == employeeId)
                .Where(wl => wl.Id == workLogId)
                .FirstOrDefault();

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.workLogs.Remove(entity);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
