using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using dominio;

namespace acceso_datos
{
    public class ItemBussiness : Bussiness<Articulo>
    {

        private static List<string> columns = new List<string> { "Codigo", "Nombre", "Descripcion", "IdMarca", "IdCategoria", "Precio" };

        public ItemBussiness() : base("ARTICULOS", "Id", columns, new ItemMapper())
        {
        }
        override public List<Articulo> getAll()
        {
            List<Articulo> articulos = new List<Articulo>();
            ImageBussiness img = new ImageBussiness();

            articulos = base.select(
                $"t.{idColumn}, t.{String.Join(" ,t.", columns)}, c.Descripcion as CatDescription, m.Descripcion as MarDescription",
                "INNER JOIN CATEGORIAS c ON c.Id=IdCategoria " +
                "INNER JOIN MARCAS m ON m.Id=IdMarca"
                );

            articulos.ForEach(a => a.Urls = img.getByIdArticulo(a.Id));

            return articulos;
        }

        override public List<Articulo> getAllFilterByTextContain(int columnaIndex, string text)
        {
            List<Articulo> articulos = new List<Articulo>();
            ImageBussiness img = new ImageBussiness();

            articulos = base.select(
                $"t.{idColumn}, t.{String.Join(" ,t.", columns)}, c.Descripcion as CatDescription, m.Descripcion as MarDescription",
                "INNER JOIN CATEGORIAS c ON c.Id=IdCategoria " +
                "INNER JOIN MARCAS m ON m.Id=IdMarca" +
                $" WHERE {columns[columnaIndex]} LIKE '%{text}%'"
                );

            articulos.ForEach(a => a.Urls = img.getByIdArticulo(a.Id));

            return articulos;
        }

        override public int saveOne(Articulo art)
        {
            int id = base.saveOne(art);

            if (id == -1)
            {
                throw new Exception("Ocurrió un error inesperado");
            }

            ImageBussiness imageBussiness = new ImageBussiness();

            foreach (Imagen img in art.Urls)
            {
                img.IdArticulo = id;
                imageBussiness.saveOne(img);
            }

            return id;
        }

        public List<Articulo> getAllFilterByName(string query)
        {
            List<Articulo> articulos = new List<Articulo>();
            ImageBussiness img = new ImageBussiness();
            articulos = this.getAllFilterByTextContain(1, query);
            articulos.ForEach(a => a.Urls = img.getByIdArticulo(a.Id));

            return articulos;

        }

        public override void deleteOne(Articulo item)
        {
            ImageBussiness imageBussiness = new ImageBussiness();

            if (item.Urls != null && item.Urls.Count > 0) { 
                imageBussiness.deleteMany(item.Urls);
            }

            base.deleteOne(item);
        }

    }
}
