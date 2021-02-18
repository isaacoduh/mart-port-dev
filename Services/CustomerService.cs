using MartPortDev.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;

        public CustomerService(AppDbContext dbContext)
        {
            _db = dbContext;
        }


        /// <summary>
        /// Adds a new Customer record
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <returns>ServiceResponse<Customer></returns>
        BaseServiceResponse<Customer> ICustomerService.CreateCustomer(Customer customer)
        {
            try {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return new BaseServiceResponse<Customer>
                {
                    IsSuccess = true,
                    Message = "New customer added",
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }catch(Exception e) {
                return new BaseServiceResponse<Customer>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
        }

        /// <summary>
        /// Deletes a customer record
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>ServiceResponse<bool></returns>

        BaseServiceResponse<bool> ICustomerService.DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            var now = DateTime.UtcNow;
            if(customer == null)
            {
                return new BaseServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Customer record not found!",
                    Data = false
                };
            }

            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                return new BaseServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Customer Removed!",
                    Data = true,
                };
            }catch(Exception e)
            {
                return new BaseServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }


        /// <summary>
        /// Returns a list of Customers from the database
        /// </summary>
        /// <returns>List<Customer></returns>
        List<Customer> ICustomerService.GetAllCustomers()
        {
            return _db.Customers.Include(customer => customer.CreatedAt).OrderBy(customer => customer.LastName).ToList();
        }

       
        Customer ICustomerService.GetById(int id)
        {
            return _db.Customers.Find(id);
        }
    }
}
