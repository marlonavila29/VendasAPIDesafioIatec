using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasAPI.Model;

namespace VendaAPI.Model
{

    public class VendedorContext : DbContext
    {
        public VendedorContext(DbContextOptions<VendedorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Vendedor> Sellers { get; set; }
    }
}
