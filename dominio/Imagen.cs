using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string Url { get; set; }
        public override string ToString()
        {
            List<string> strings = new List<string>();

            if (Id != -1)
            {
                strings.Add(Id.ToString());
            }
            if (Url != null)
            {
                strings.Add(Url);
            }

            return string.Join(", ", strings);
        }
    }
}
