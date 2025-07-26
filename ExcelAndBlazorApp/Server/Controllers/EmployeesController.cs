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

        public EmployeesController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = _dbContext.employees
                .Select(e => new EmployeeDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    PESEL = e.PESEL,
                    Position = e.Position,
                    HourlyRateGross = e.HourlyRateGross
                }).ToList();

            if (employees is null)
                return NotFound();

            return Ok(employees);
        }

        [HttpGet]
        [Route("work-logs/{id}")]
        public ActionResult<IEnumerable<EmployeeDto>> GetWorkLogs([FromRoute] int Id)
        {
            var employees = _dbContext.employees
                .Include(wl => wl.WorkLogs)
                .Where(wl => wl.Id == Id)
                .Select(e => new EmployeeDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    PESEL = e.PESEL,
                    Position = e.Position,
                    HourlyRateGross = e.HourlyRateGross,
                    WorkLogs = e.WorkLogs.Select(wl => new WorkLogDto()
                    {
                        Id = wl.Id,
                        EmployeeId = wl.EmployeeId,
                        Date = wl.Date,
                        HoursWorked = wl.HoursWorked,
                        CostGross = wl.HoursWorked * e.HourlyRateGross,
                        CostNet = (wl.HoursWorked * e.HourlyRateGross) / 1.23m
                    }).ToList()
                }).FirstOrDefault();

            if (employees is null)
                return NotFound();

            return Ok(employees);
        }
    }
}
