using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MartPortDev.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialStock> MaterialStocks { get; set; }
        public virtual DbSet<MaterialStockSnapshot> MaterialStockSnapshots { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }

    }
}
