using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Services;
using MartPortDev.Serialization;
using MartPortDev.ViewModels;
using Microsoft.Extensions.Logging;

namespace MartPortDev.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Creating a new customer");
            customer.CreatedAt = DateTime.UtcNow;
            customer.UpdatedAt = DateTime.UtcNow;
            var customerData = CustomerMapper.SerializeCustomer(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

       [HttpGet("/api/customer")]
       public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting customers");
            var customers = _customerService.GetAllCustomers();
            var customerModels = customers.Select(customer => new CustomerModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerDetail = CustomerMapper.MapCustomerDetail(customer.customerDetails),
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            }).OrderByDescending(customer => customer.CreatedAt).ToList();
            return Ok(customerModels);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting a customer");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}
