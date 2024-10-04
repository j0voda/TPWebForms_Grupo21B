using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    public class ImageMapper : IDBMapper<Imagen>
    {
        public string getIdentifier(Imagen obj)
        {
            return obj.Id.ToString();
        }

        public List<string> mapFromObject(Imagen obj)
        {
            List<string> args = new List<string>();

            args.Add($"{obj.IdArticulo}");
            args.Add($"'{obj.Url}'");

            return args;
        }

        public Imagen mapToObject(SqlDataReader reader)
        {
            Imagen ima = new Imagen();

            ima.Id = reader.GetInt32(0);
            ima.Url = reader.GetString(1);

            return ima;
        }
    }
}
