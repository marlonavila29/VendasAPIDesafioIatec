using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasAPI.Model;

namespace VendasAPI.Repository
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> Get();

        Task<Vendedor> Get(int id);

        Task<Vendedor> Create(Vendedor vendedor);

        Task Update(Vendedor vendedor);

        Task Delete(int id);
    }
}
