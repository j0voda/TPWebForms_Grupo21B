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
                "Documento", 
                new List<string> { "Nombre", "Apellido", "Email", "Direccion", "Ciudad", "CP" }, 
                new ClientMapper()
                )
        {
        }
    }
}
