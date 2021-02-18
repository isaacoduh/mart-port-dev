using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;

namespace MartPortDev.Services
{
    public interface IOrderService
    {
        List<SalesOrder> GetOrders();
        BaseServiceResponse<bool> GenerateOpenOrder(SalesOrder order);
        BaseServiceResponse<bool> MarkAsFulfilled(int id);
    }
}
