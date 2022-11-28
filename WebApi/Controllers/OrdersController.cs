using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var orderEntity = new OrderEntity
                {
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    CustomerName = model.CustomerName,
                    StreetName = model.StreetName,
                    StreetNumber = model.StreetNumber,
                    PostalCode = model.PostalCode,
                    City = model.City,
                };
                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = new List<OrderModel>();
            foreach (var order in await _context.Orders.ToListAsync())
                orders.Add(new OrderModel
                {
                    Id = order.Id,
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    CustomerName = order.CustomerName,
                    StreetName = order.StreetName,
                    StreetNumber = order.StreetNumber,
                    PostalCode = order.PostalCode,
                    City = order.City
                });
            return new OkObjectResult(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if(orderEntity != null)
                return new OkObjectResult(new OrderModel
                {
                    Id=orderEntity.Id,
                    CreatedDate= DateTime.Now,
                    DueDate= DateTime.Now,
                    CustomerName = orderEntity.CustomerName,
                    StreetName= orderEntity.StreetName,
                    StreetNumber= orderEntity.StreetNumber,
                    PostalCode= orderEntity.PostalCode,
                    City = orderEntity.City,
                });
            return new NotFoundResult();
        }
    }
}
