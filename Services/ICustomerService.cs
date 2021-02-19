using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.Services
{
    public interface ICustomerService
    {
        List<Data.Customer> GetAllCustomers();
        BaseServiceResponse<Data.Customer> CreateCustomer(Data.Customer customer);
        BaseServiceResponse<bool> DeleteCustomer(int id);
        Data.Customer GetById(int id);
    }
}
