using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sellers.Model
{
    public class SellerContext : DbContext
    {
        public SellerContext(DbContextOptions<SellerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Seller> Sellers { get; set; }
    }
}
