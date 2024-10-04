using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acceso_datos
{
    internal class ClientMapper : IDBMapper<Cliente>
    {
        public string getIdentifier(Cliente obj)
        {
            return obj.Id.ToString();
        }

        public List<string> mapFromObject(Cliente obj)
        {
            return new List<string>();
        }

        public Cliente mapToObject(SqlDataReader reader)
        {
            Cliente client = new Cliente();

            client.Documento = reader.GetString(0);
            client.Nombre = reader.GetString(1);
            client.Apellido = reader.GetString(2);
            client.Email = reader.GetString(3);
            client.Direccion = reader.GetString(4);
            client.Ciudad = reader.GetString(5);
            client.CodigoPostal = reader.GetInt32(6);

            return client;
        }
    }
}
