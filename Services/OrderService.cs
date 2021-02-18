using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MartPortDev.Data;
using MartPortDev.Services;

namespace MartPortDev.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<OrderService> _logger;
        private readonly IMaterialService _materialService;
        private readonly IStockService _stockService;

        public OrderService(AppDbContext db, ILogger<OrderService> logger, IMaterialService materialService, IStockService stockService)
        {
            _db = db;
            _logger = logger;
            _materialService = materialService;
            _stockService = stockService;
        }

        public List<SalesOrder> GetOrders()
        {
            return _db.SalesOrders.Include(so => so.Customer).ThenInclude(customer => customer.customerDetails).Include(so => so.SalesOrderItems).ThenInclude(item => item.Material).ToList();
        }

        /// <summary>
        /// Creates an open SalesOrder
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// 
        public BaseServiceResponse<bool> GenerateOpenOrder(SalesOrder order)
        {
            var now = DateTime.UtcNow;
            _logger.LogInformation("Generating new Order");
            foreach(var item in order.SalesOrderItems)
            {
                item.Material = _materialService.GetMaterialById(item.Material.Id);
                var stockId = _stockService.GetByMaterialId(item.Material.Id).Id;
                _stockService.ModifyAvailableUnits(stockId, -item.Quantity);
            }


            try
            {
                _db.SalesOrders.Add(order);
                _db.SaveChanges();

                return new BaseServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "Open Order Created!",
                    Time = now
                };
            }catch(Exception e)
            {
                return new BaseServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }

        /// <summary>
        /// Marks an open SalesOrder as paid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public BaseServiceResponse<bool> MarkAsFulfilled(int id)
        {
            var now = DateTime.UtcNow;
            var order = _db.SalesOrders.Find(id);
            order.UpdatedAt = now;
            order.IsPaid = true;

            try
            {
                _db.SalesOrders.Update(order);
                _db.SaveChanges();
                return new BaseServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Order {order.Id} closed: Invoice paid",
                    Time = now
                };
            }catch(Exception e)
            {
                return new BaseServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }
    }
}
