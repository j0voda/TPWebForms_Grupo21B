using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace acceso_datos
{
    internal class ClientBussiness : Bussiness<Cliente>
    {

        public ClientBussiness(IDBMapper<Cliente> mapper) : 
            base(
                "Clientes", 
                "Id", 
                new List<string> { "Documento", "Nombre", "Apellido", "Email", "Direccion", "Ciudad", "CP" }, 
                mapper
                )
        {
        }
    }
}
