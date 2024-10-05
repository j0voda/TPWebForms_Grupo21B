using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
        public override string ToString()
        {
            List<string> strings = new List<string>();

            if (Documento != null)
            {
                strings.Add(Documento);
                strings.Add(Nombre);
                strings.Add(Apellido);
                strings.Add(Email);
                strings.Add(Direccion);
                strings.Add(Ciudad);
                strings.Add(CodigoPostal.ToString());
            }

            return string.Join(", ", strings);
        }
    }
}
