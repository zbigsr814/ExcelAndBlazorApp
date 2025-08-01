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
    public class OrdersController : ControllerBase
    {
        private readonly CompanyDbContext _dbContext;
		private readonly IMapper _mapper;

		public OrdersController(CompanyDbContext _dbContext, IMapper mapper)
        {
            this._dbContext = _dbContext;
			_mapper = mapper;
		}

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _dbContext.orders
                .Include(o => o.Items)
                .ToList();
            var dtos = _mapper.Map<List<OrderDto>>(orders);

            if (orders is null)
                return NotFound();

            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderDto> GetOrderItems([FromRoute] int Id)
        {
            var order = _dbContext.orders
                .Include(o => o.Items)
                .Where(o => o.Id == Id)
                .FirstOrDefault();          //

            var dto = _mapper.Map<OrderDto>(order);

            if (order is null)
                return NotFound();

            return Ok(dto);
        }

		[HttpPost]
		public IActionResult PostOrder([FromBody] OrderDto order)
		{
			var entity = _mapper.Map<Order>(order);

			_dbContext.orders.Add(entity);
			_dbContext.SaveChanges();

			return Ok();
		}

		[HttpPost("{id}")]
		public IActionResult PostOrderItem([FromBody] OrderItemDto orderItem)
		{
			var entity = _mapper.Map<OrderItem>(orderItem);

			_dbContext.orderItems.Add(entity);
			_dbContext.SaveChanges();

			return Ok();
		}

		[HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var entity = _dbContext.orders.FirstOrDefault(c => c.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.orders.Remove(entity);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{orderId}/{orderItemId}")]
        public IActionResult DeleteWorkLog([FromRoute] int orderId, [FromRoute] int orderItemId)
        {
            var entity = _dbContext.orderItems
                .Where(wl => wl.OrderId == orderId)
                .Where(wl => wl.Id == orderItemId)
                .FirstOrDefault();

            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.orderItems.Remove(entity);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
