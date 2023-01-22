using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Model;

namespace Sales.Repository
{
    public class SaleRepository : ISaleRepository
    {
        public readonly SaleContext _context;
        public SaleRepository(SaleContext context)
        {
            _context = context;
        }
        public async Task<Sale> Create(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task Delete(int id)
        {
            var saleToDelete = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(saleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sale>> Get()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> Get(int id)
        {
            return await _context.Sales.FindAsync();
        }

        public async Task Update(Sale sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
