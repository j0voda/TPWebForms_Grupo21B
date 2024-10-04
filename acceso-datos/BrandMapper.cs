using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace acceso_datos
{
    public class BrandMapper : IDBMapper<Marca>
    {
        public string getIdentifier(Marca obj)
        {
            return obj.Id.ToString();
        }

        public List<string> mapFromObject(Marca obj)
        {
            //return new List<string>();
            List<string> desc = new List<string>();
            desc.Add($"'{obj.Descripcion}'");
            return desc;
        }

        public Marca mapToObject(SqlDataReader reader)
        {
            Marca mar = new Marca();

            mar.Id = reader.GetInt32(0);
            mar.Descripcion = reader.GetString(1);

            return mar;
        }
    }
}
