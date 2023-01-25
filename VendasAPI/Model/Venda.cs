using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasAPI.Model
{
    public class Venda
    {
        public int Id{ get; set; }
        public String ItensVenda  { get; set; }
        public String Status { get; set; }
        public int DataVenda { get; set; }
        public int IdVendedor { get; set; }

    }
}
