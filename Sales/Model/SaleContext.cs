using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Model;

namespace Sales.Model
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Sale> Sales { get; set; }
    }
}
