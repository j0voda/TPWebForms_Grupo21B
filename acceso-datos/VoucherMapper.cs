using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    internal class VoucherMapper : IDBMapper<Voucher>
    {
        public string getIdentifier(Voucher obj)
        {
            return $"'{obj.Codigo}'";
        }

        public List<string> mapFromObject(Voucher obj)
        {
            throw new NotImplementedException();
        }

        public Voucher mapToObject(SqlDataReader reader)
        {
            Voucher voucher = new Voucher();

            voucher.Codigo = reader.GetString(0);
            
            voucher.Cliente = new Cliente();
            voucher.Cliente.Id = reader[1] as int? ?? default;

            voucher.FechaCanje = reader[2] as DateTime? ?? default;

            voucher.Articulo = new Articulo();
            voucher.Articulo.Id = reader[3] as int? ?? default;

            voucher.Used = reader[1] as int? != null;

            return voucher;
        }
    }
}
