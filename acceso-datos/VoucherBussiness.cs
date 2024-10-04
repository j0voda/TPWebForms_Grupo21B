using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    internal class VoucherBussiness : Bussiness<Voucher>
    {
        public VoucherBussiness(IDBMapper<Voucher> mapper) : 
            base("Vouchers", "CodigoVoucher", new List<string>() { "IdCliente", "FechaCanje", "IdArticulo" }, mapper)
        {
        }
    }
}
