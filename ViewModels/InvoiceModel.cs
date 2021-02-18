using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartPortDev.ViewModels
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }
    /// <summary>
    /// View model for SalesOrderItems
    /// </summary>
    public class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public MaterialModel Material { get; set; }
    }
}
