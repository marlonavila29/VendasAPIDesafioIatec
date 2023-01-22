using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasAPI.Model;

namespace VendasAPI.Repository
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> Get();

        Task<Venda> Get(int id);

        Task<Venda> Create(Venda venda);

        Task Update(Venda venda);

        Task Delete(int id);

    }
}
