using ExcelAndBlazorApp.Entities;
using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;

namespace ExcelAndBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly CompanyDbContext _dbContext;

        public OrdersController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _dbContext.orders
                .Select(o => new OrderDto()
                {
                    Id = o.Id,
                    Date = o.Date,
                    OrderNumber = o.OrderNumber,
                    TotalGross = o.TotalGross,
                    TotalNet = o.TotalNet
                })
                .ToList();

            if (orders is null)
                return NotFound();

            return Ok(orders);
        }

        [HttpGet]
        [Route("order-items/{id}")]
        public ActionResult<OrderDto> GetOrderItems([FromRoute] int Id)
        {
            var order = _dbContext.orders
                .Include(o => o.Items)
                .Where(o => o.Id == Id)
                .Select(o => new OrderDto()
                {
                    Id = o.Id,
                    Date = o.Date,
                    OrderNumber = o.OrderNumber,
                    TotalGross = o.TotalGross,
                    TotalNet = o.TotalNet,
                    Items = o.Items.Select(oi => new OrderItemDto()
                    {
                        Id = oi.Id,
                        ItemName = oi.ItemName,
                        OrderId = oi.OrderId,
                        PriceGross = oi.PriceGross,
                        Quantity = oi.Quantity
                    }).ToList()

                })
            .FirstOrDefault();

            if (order is null)
                return NotFound();

            return Ok(order);
        }
    }
}
