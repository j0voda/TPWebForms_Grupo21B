using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {

        public Categoria() {
            Id = -1;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            List<string> strings = new List<string>();

            if (Id != -1) {
                strings.Add(Id.ToString());
            }
            if (Descripcion != null) {
                strings.Add(Descripcion);
            }

            return string.Join(", ", strings);
        }
    }
}
