using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;
using MartPortDev.ViewModels;

namespace MartPortDev.Serialization
{
    public class CustomerMapper
    {
        /// <summary>
        /// Serializes a Customer data model into a CustomerModel view model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// 
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                FirstName = customer.FirstName,
                LastName = customer.LastName,

                CustomerDetail = MapCustomerDetail(customer.customerDetails),
            };
        }

        /// <summary>
        /// Serializes a CustomerModel view model into a Customer data model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// 
        public static Customer SerializeCustomer(CustomerModel customer)
        {
            return new Customer
            {
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                customerDetails = MapCustomerDetail(customer.CustomerDetail),
            };
        }

        /// <summary>
        /// Maps a CustomerDetail data model to a CustomerDetailModel view model
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// 
        public static CustomerDetailModel MapCustomerDetail(CustomerDetail detail)
        {
            return new CustomerDetailModel
            {
                Id = detail.Id,
                Email = detail.Email,
                Phone = detail.Phone,
                PrimaryAddress = detail.PrimaryAddress,
                AlternateAddress = detail.AlternateAddress,
                City = detail.City,
                State = detail.State,
                PostalCode = detail.PostalCode,
                Country = detail.Country,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
        }

        public static CustomerDetail MapCustomerDetail(CustomerDetailModel detail)
        {
            return new CustomerDetail
            {
                Email = detail.Email,
                Phone = detail.Phone,
                PrimaryAddress = detail.PrimaryAddress,
                AlternateAddress = detail.AlternateAddress,
                City = detail.City,
                State = detail.State,
                PostalCode = detail.PostalCode,
                Country = detail.Country,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
        }
    }
}
