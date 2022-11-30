using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(ProductCreateModel model)
        {
            try
            {
                var productEntity = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
            }
            catch { }
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var product in await _context.Products.ToListAsync())
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
            return products;
        }

        public async Task<ProductModel> Get(Guid id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
                return new ProductModel { Id = productEntity.Id, Name = productEntity.Name, Description = productEntity.Description, Price = productEntity.Price };

            return null!;
        }
    }
}
