using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    public class CategoryMapper : IDBMapper<Categoria>
    {
        public string getIdentifier(Categoria obj)
        {
            return obj.Id.ToString();
        }

        public List<string> mapFromObject(Categoria obj)
        {
            List<string> args = new List<string>();
            args.Add($"'{obj.Descripcion}'");
            return args;
        }

        public Categoria mapToObject(SqlDataReader reader)
        {
            Categoria cat = new Categoria();

            cat.Id = reader.GetInt32(0);
            cat.Descripcion = reader.GetString(1);

            return cat;
        }
    }
}
