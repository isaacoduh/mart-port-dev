using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.ViewModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CustomerModel Customer { get; set; }
        public List<SalesOrderItemModel> SalesOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}
