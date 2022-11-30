using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public class OrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(OrderCreateModel model)
        {
            var orderEntity = new OrderEntity
            {
                CustomerName = model.CustomerName,
                CreatedDate = model.CreatedDate,
                DueDate = model.DueDate,
                TotalPrice = model.TotalPrice,
                StreetName = model.StreetName,
                StreetNumber = model.StreetNumber,
                PostalCode = model.PostalCode,
                City = model.City,
            };
            _context.Add(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            var orders = new List<OrderModel>();
            foreach (var order in await _context.Orders.ToListAsync())
                orders.Add(new OrderModel
                {
                    Id = order.Id,
                    CustomerName = order.CustomerName,
                    CreatedDate = order.CreatedDate,
                    TotalPrice = order.TotalPrice,
                    StreetName = order.StreetName,
                    StreetNumber = order.StreetNumber,
                    PostalCode = order.PostalCode,
                    City = order.City,

                });
            return orders;
        }

        public async Task<OrderModel> Get(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity != null)
                return new OrderModel
                {
                    Id = orderEntity.Id,
                    CustomerName = orderEntity.CustomerName,
                    CreatedDate = orderEntity.CreatedDate,
                    DueDate = orderEntity.DueDate,
                    TotalPrice = orderEntity.TotalPrice,
                    StreetName = orderEntity.StreetName,
                    StreetNumber = orderEntity.StreetNumber,
                    PostalCode = orderEntity.PostalCode,
                    City = orderEntity.City
                };

            return null!;
        }
    }
}
