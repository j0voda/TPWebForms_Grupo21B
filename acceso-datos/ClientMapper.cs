using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace acceso_datos
{
    internal class ClientMapper : IDBMapper<Cliente>
    {
        public string getIdentifier(Cliente obj)
        {
            return obj.Documento;
        }

        public List<string> mapFromObject(Cliente obj)
        {
            List<string> strings = new List<string>();
            strings.Add(obj.Documento);
            strings.Add(obj.Nombre);
            strings.Add(obj.Apellido);
            strings.Add(obj.Email);
            strings.Add(obj.Direccion);
            strings.Add(obj.Ciudad);
            strings.Add(obj.CodigoPostal.ToString());

            return strings;
        }

        public Cliente mapToObject(SqlDataReader reader)
        {
            Cliente client = new Cliente();


            client.Id = Convert.ToInt32(reader[0]);
            client.Documento = reader.GetString(1);
            client.Nombre = reader.GetString(2);
            client.Apellido = reader.GetString(3);
            client.Email = reader.GetString(4);
            client.Direccion = reader.GetString(5);
            client.Ciudad = reader.GetString(6);
            client.CodigoPostal = reader.GetInt32(7);

            return client;
        }
    }
}
