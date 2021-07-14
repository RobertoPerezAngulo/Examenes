using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TaskAgile.Models.Articulo;

namespace TaskAgile.Models
{
    public class FuncionesArticles
    {
        public Task<List<Article>> LlenarArticulos()
        {
            return Task.Run(() =>
            {
                Article _arcticulo;
                List<Article> _articulos = new List<Article>();

                _arcticulo = new Article
                {
                    Id = new Guid(),
                    Title = "Principito",
                    Text = "el roberto"
                };
                _articulos.Add(_arcticulo);

                _arcticulo = new Article
                {
                    Id = Guid.NewGuid(),
                    Title = "Principito2",
                    Text = "el roberto2"
                };
                _articulos.Add(_arcticulo);

                _arcticulo = new Article
                {
                    Id = Guid.NewGuid(),
                    Title = "El perro",
                    Text = "el roberto3"
                };
                _articulos.Add(_arcticulo);
                return _articulos.Count > 0 ? _articulos : new List<Article>();
            });
        }

        public async Task<List<Article>> UpdateLibros(string aId, Article articulo)
        {
            List<Article> _articulos = await LlenarArticulos();
            try
            {

                var update = _articulos.Find(x => x.Id == new Guid(aId));
                if (update == null)
                    throw new Exception("Usuario no encontrado");
                _articulos.First(x => x.Id == update.Id).Id = articulo.Id;
                _articulos.First(x => x.Id == update.Id).Text = articulo.Text;
                _articulos.First(x => x.Id == update.Id).Title = articulo.Title;
            }
            catch (Exception)
            {

            }
            return _articulos;
        }

        public async Task<List<Article>> RegistraArticulo(Article _articulo)
        {
            List<Article> _articulos = await LlenarArticulos();
            try
            {
                long i = 0;
                i = _articulos.Count;
                _articulos.Add(_articulo);
                if (_articulos.Count != i + 1)
                    throw new Exception("No se pudo guardar el nuevo elemento");
            }
            catch (Exception)
            {
                _articulos = new List<Article>();
            }
            return _articulos;
        }

        public async Task<List<Article>> BorrarArticle(Guid art)
        {
            FuncionesArticles obj = new FuncionesArticles();
            List<Article> _articulos = await obj.LlenarArticulos();
            try
            {
                var articuloborrado = _articulos.Find(x => x.Id == art);
                _articulos.Remove(articuloborrado);
            }
            catch (Exception)
            {

            }
            return _articulos;
        }
    }
}
