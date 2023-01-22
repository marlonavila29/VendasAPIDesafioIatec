using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaAPI.Model;
using VendasAPI.Model;

namespace VendasAPI.Repository
{
    public class VendedorRepository : IVendedorRepository
    {

        public readonly VendedorContext _context;
        public VendedorRepository(VendedorContext context)
        {
            _context = context;
        }
        public async Task<Vendedor> Create(Vendedor seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task Delete(int id)
        {
            var sellerToDelete = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(sellerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vendedor>> Get()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Vendedor> Get(int id)
        {
            return await _context.Sellers.FindAsync();
        }

        public async Task Update(Vendedor seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
