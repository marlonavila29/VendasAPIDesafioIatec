using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sellers.Model;

namespace Sellers.Repository
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> Get();

        Task<Seller> Get(int id);

        Task<Seller> Create(Seller seller);

        Task Update(Seller seller);

        Task Delete(int id);
    }
}
