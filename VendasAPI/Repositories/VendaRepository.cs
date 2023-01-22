using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasAPI.Model;

namespace VendasAPI.Repository
{

    public class VendaRepository : IVendaRepository
    {

        public readonly VendaContext _context;
        public VendaRepository(VendaContext context)
        {
            _context = context;
        }
        public async Task<Venda> Create(Venda sale)
        {
            _context.Vendas.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task Delete(int id)
        {
            var saleToDelete = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(saleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venda>> Get()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task<Venda> Get(int id)
        {
            return await _context.Vendas.FindAsync();
        }

        public async Task Update(Venda sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
