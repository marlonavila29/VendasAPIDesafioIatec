using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasAPI.Model
{

    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Venda> Vendas { get; set; }
    }
}
