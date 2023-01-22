using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Model
{
    public class Sale
    {
        public int Id{ get; set; }
        public String SaleItem  { get; set; }
        public String Status { get; set; }
        public int SaleDate { get; set; }

    }
}
