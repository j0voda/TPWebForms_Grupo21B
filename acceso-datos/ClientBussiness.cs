using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace acceso_datos
{
    public class ClientBussiness : Bussiness<Cliente>
    {

        public ClientBussiness() : 
            base(
                "Clientes", 
                "Id", 
                new List<string> { "Documento", "Nombre", "Apellido", "Email", "Direccion", "Ciudad", "CP" }, 
                new ClientMapper()
                )
        {
        }

        override public int saveOne(Cliente c)
        {
            int id = -1;
            sqlConexion.Open();

            string query = String.Format("INSERT INTO {0} ({1}) ", tableName, String.Join(" ,", columns));
            query += $"VALUES('{c.Documento}', '{c.Nombre}', '{c.Apellido}', '{c.Email}', '{c.Direccion}', '{c.Ciudad}', '{c.CodigoPostal}'); SELECT SCOPE_IDENTITY();";
            reader = this.executeCommand(query);

            if (reader.Read())
            {
                id = Convert.ToInt32(reader[0]);
            }

            sqlConexion.Close();

            return id;
        }
    }
}
