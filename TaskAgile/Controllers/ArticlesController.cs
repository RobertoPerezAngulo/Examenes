using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAgile.Models;
using static TaskAgile.Models.Articulo;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAgile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        [HttpGet("GET_Articulos")]
        public async Task<List<Article>> GetArticulos()
        {
            FuncionesArticles obj = new FuncionesArticles();
            return await obj.LlenarArticulos();
        }

        [HttpGet("GET")]
        public async Task<Article> GetArticulos(string art)
        {
            FuncionesArticles obj = new FuncionesArticles();
            List<Article> _articulo = await obj.LlenarArticulos();
            return string.IsNullOrEmpty(_articulo.FirstOrDefault(x => x.Id == new Guid(art)).Id.ToString()) ? new Article() : _articulo.FirstOrDefault(x => x.Id == new Guid(art));
        }

        [HttpPut("PUT")]
        public async Task<List<Article>> UpdateLibros(string aId, Article articulo)
        {
            FuncionesArticles obj = new FuncionesArticles();
            return await obj.UpdateLibros(aId, articulo);
        }

        [HttpPost("POST")]
        public async Task<List<Article>> RegistraArticulo(Article _articulo)
        {
            FuncionesArticles obj = new FuncionesArticles();
            return await obj.RegistraArticulo(_articulo);
        }

        [HttpDelete("DELETE")]
        public async Task<List<Article>> BorrarArticle(Guid art)
        {
            FuncionesArticles obj = new FuncionesArticles();
            return await obj.BorrarArticle(art);
        }

    }
}
