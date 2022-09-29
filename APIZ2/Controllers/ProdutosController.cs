using Microsoft.AspNetCore.Mvc;
using APIZ2.Context;
using APIZ2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIZ2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
            {
                return BadRequest();
            }
            return Ok(produtos);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetId(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return BadRequest();
            }
            return Ok(produto);
        }
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if(produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id,[FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok();
        }

    }
}
