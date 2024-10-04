using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    public class ItemMapper : IDBMapper<Articulo>
    {
        public string getIdentifier(Articulo obj)
        {
            return obj.Id.ToString();
        }

        public List<string> mapFromObject(Articulo obj)
        {

            List<string> args = new List<string>();

            args.Add($"'{obj.Codigo}'");
            args.Add($"'{obj.Nombre}'");
            args.Add($"'{obj.Descripcion}'");
            args.Add($"{obj.Marca.Id}");
            args.Add($"{obj.Categoria.Id}");
            args.Add($"{obj.Precio.ToString().Replace(',', '.')}");

            return args;
        }

        public Articulo mapToObject(SqlDataReader reader)
        {
            Articulo art = new Articulo();

            art.Id = reader.GetInt32(0);
            art.Codigo = reader.GetString(1);
            art.Nombre = reader.GetString(2);
            art.Descripcion = reader.GetString(3);
            art.Marca = new Marca();
            art.Marca.Id = reader.GetInt32(4);
            art.Marca.Descripcion = (string)reader["MarDescription"];
            art.Categoria = new Categoria();
            art.Categoria.Id= reader.GetInt32(5);
            art.Categoria.Descripcion = (string)reader["CatDescription"];
            art.Precio = reader.GetDecimal(6);
            //art.Urls = (from IDataRecord r in reader select (string)r["Urls"]).ToList();

            return art;
        }
    }
}
