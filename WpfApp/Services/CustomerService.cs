using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.Entities;
using WpfApp.Contexts;

namespace WpfApp.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }


        public async Task Create(CustomerCreateModel model)
        {
            try
            {
                var customerEntity = new CustomerEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address
                };
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
            }
            catch { }
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Phone = customer.Phone, Address = customer.Address });
            return customers;
        }

        public async Task<CustomerModel> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerModel { Id = customerEntity.Id, FirstName = customerEntity.FirstName, LastName = customerEntity.LastName, Email = customerEntity.Email, Phone = customerEntity.Phone, Address = customerEntity.Address };

            return null!;
        }

        public async Task<IActionResult> PutCustomerEntity(int id, CustomerModel customerModel)
        {
            try
            {
                if (id != customerModel.Id)
                {
                    return new BadRequestResult();
                }
                var customerEntity = await _context.Customers.FindAsync(id);
                if (customerEntity != null)
                {
                    customerEntity.FirstName = customerModel.FirstName;
                    customerEntity.LastName = customerModel.LastName;
                    customerEntity.Email = customerModel.Email;
                    customerEntity.Phone = customerModel.Phone;
                    customerEntity.Address = customerModel.Address;

                    await _context.SaveChangesAsync();

                    return new OkResult();
                }
                return new NotFoundResult();
               
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            try
            {
                var customerEntity = await _context.Customers.FindAsync(id);
                if (customerEntity == null)
                    return new NotFoundResult();
                _context.Customers.Remove(customerEntity);
                await _context.SaveChangesAsync();

                return new OkResult();
            }catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
