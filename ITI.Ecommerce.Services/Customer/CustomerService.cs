using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _context;

     

       public CustomerService(ApplicationDbContext context)


        {
            _context = context;
        }

        public async Task add(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
               
                IsDeleted = customerDto.IsDeleted,
                UserName = customerDto.FullName,
                Address =   customerDto.Address,
                MobileNumber = customerDto.MobileNumber ,
                Email = customerDto.Email,
                DateEntered = customerDto.DateEntered
            };
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        public void Delete(string ID)
        {
            //Customer customer = new Customer()
            //{
            //    Id = customerDto.ID,

            //    IsDeleted = true,
            //    UserName = customerDto.FullName,
            //    Address = customerDto.Address,
            //    MobileNumber = customerDto.MobileNumber,
            //    Email = customerDto.Email,
            //    DateEntered = customerDto.DateEntered
            //};
            //_context.Update(customer);
            //_context.SaveChanges();
            var Product = _context.Customers.SingleOrDefault(p => p.Id == ID);
            
            Product.IsDeleted = true;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            List<CustomerDto> customerDtosList = new List<CustomerDto>();
            var Customiers = await _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();
            foreach (var customer in Customiers)
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    ID = customer.Id,
                   
                    IsDeleted = customer.IsDeleted,
                    FullName = customer.UserName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                customerDtosList.Add(customerDto);
            }
            return customerDtosList;
        }

        public  async Task<IEnumerable<CustomerDto>> GetAllDeleted()
        {
            List<CustomerDto> customerDtosList = new List<CustomerDto>();
            var Customiers = await _context.Customers.Where(c => c.IsDeleted == true).ToListAsync();
            foreach (var customer in Customiers)
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    ID = customer.Id,

                    IsDeleted = customer.IsDeleted,
                    FullName = customer.UserName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                customerDtosList.Add(customerDto);
            }
            return customerDtosList;
        }

        public async Task<CustomerDto> GetById(string id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(o => o.Id == id);
            if (customer == null)
            {
                throw new Exception("this customer not found");
            }
            else
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    ID = customer.Id,
                   
                    IsDeleted = customer.IsDeleted,
                    FullName = customer.UserName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                return customerDto;
            }
        }

        public void Restore(string id)
        {
            var Product = _context.Customers.SingleOrDefault(p => p.Id == id);

            Product.IsDeleted = false;
            _context.SaveChanges();
        }

        public void Update(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = customerDto.ID,
               
                IsDeleted = customerDto.IsDeleted,
                UserName = customerDto.FullName,
                Address = customerDto.Address,
                MobileNumber = customerDto.MobileNumber,
                Email = customerDto.Email,
                DateEntered = customerDto.DateEntered

            };

            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}
