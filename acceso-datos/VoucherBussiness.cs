using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    public class VoucherBussiness : Bussiness<Voucher>
    {
        public VoucherBussiness() : 
            base("Vouchers", "CodigoVoucher", new List<string>() { "IdCliente", "FechaCanje", "IdArticulo" }, new VoucherMapper())
        {
        }
    }
}
