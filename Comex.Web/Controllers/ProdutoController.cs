using Microsoft.AspNetCore.Mvc;
using Comex.Web.Data.Dto;
using Comex.Models;
using Comex.Models.Extensoes;

namespace Comex.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> _produtos = new List<Produto>();

        [HttpGet]
        public IActionResult RetornaMomento()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] CriarProdutoDto produto)
        {
            if (ModelState.IsValid)
            {
                _produtos.Add(new Produto(produto.Nome, produto.PrecoUnitario, produto.QuantidadeEmEstoque, produto.Categoria));
                var created = _produtos.Last();
                return CreatedAtAction(nameof(ObterProdutoPorId), new {Id = created.Id }, created);
            }
            else
                return BadRequest(produto);
        }

        [HttpGet("{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto.IsNull())
                return NotFound();
            return Ok(produto);
        }
    }
}


