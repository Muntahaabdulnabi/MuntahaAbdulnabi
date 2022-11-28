using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var customerEntity = new CustomerEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address
                };
                _context.Customers.Add(customerEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Phone = customer.Phone, Address = customer.Address });
            return new OkObjectResult(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new OkObjectResult(new CustomerModel { Id = customerEntity.Id, FirstName = customerEntity.FirstName, LastName = customerEntity.LastName, Email = customerEntity.Email, Phone = customerEntity.Phone, Address = customerEntity.Address });
           
            return new NotFoundResult();
        }
       
    }
}
