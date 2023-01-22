using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Model;

namespace Sales.Repository
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> Get();

        Task<Sale> Get(int id);

        Task<Sale> Create(Sale sale);

        Task Update(Sale sale);

        Task Delete(int id);

    }
}
