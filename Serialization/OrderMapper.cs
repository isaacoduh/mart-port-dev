using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MartPortDev.Data;
using MartPortDev.ViewModels;

namespace MartPortDev.Serialization
{
    public class OrderMapper
    {
        public static SalesOrder SerializeInvoiceToOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems.Select(item => new SalesOrderItem
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Material = MaterialMapper.SerializeMaterialModel(item.Material)
            }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static List<OrderModel> SerializeOrderToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel
            {
                Id = order.Id,
                UpdatedAt = order.UpdatedAt,
                CreatedAt = order.CreatedAt,
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Material = MaterialMapper.SerializeMaterialModel(item.Material)
            }).ToList();
        }
    }
}
