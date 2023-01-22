using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sellers.Model;

namespace Sellers.Repository
{
    public class SellerRepository : ISellerRepository
    {
        public readonly SellerContext _context;
        public SellerRepository(SellerContext context)
        {
            _context = context;
        }
        public async Task<Seller> Create(Seller seller)
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

        public async Task<IEnumerable<Seller>> Get()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> Get(int id)
        {
            return await _context.Sellers.FindAsync();
        }

        public async Task Update(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
