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

    }
}
