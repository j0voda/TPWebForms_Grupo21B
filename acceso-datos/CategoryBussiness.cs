using dominio;
using System.Collections.Generic;

namespace acceso_datos
{
    public class CategoryBussiness : Bussiness<Categoria>
    {
        public CategoryBussiness() : base("CATEGORIAS", "Id", new List<string> { "Descripcion" } , new CategoryMapper())
        {

        }
    }
}
