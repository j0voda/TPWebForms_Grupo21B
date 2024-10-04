using dominio;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace acceso_datos
{
    public class BrandBussiness : Bussiness<Marca>
    {
        public BrandBussiness() : base("MARCAS", "Id", new List<string> { "Descripcion" } , new BrandMapper()) 
        {
        }

        public override int insert(string values)
        {
            int id = -1;
            base.sqlConexion.Open();

            string query = String.Format("INSERT INTO {0} ({1}) VALUES ({2});SELECT SCOPE_IDENTITY();", tableName, String.Join(" ,", columns), values);
            reader = base.executeCommand(query);

            if (reader.Read())
            {
                id = Convert.ToInt32(reader[0]);
            }

            sqlConexion.Close();

            return id;
        }
    }
}
