using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {

        public string Codigo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public Articulo Articulo { get; set; }
        public bool Used { get; set; }
    }
}
