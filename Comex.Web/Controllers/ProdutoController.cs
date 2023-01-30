using Microsoft.AspNetCore.Mvc;
using Comex.Web.Data.Dto;

namespace Comex.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult RetornaMomento()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] CriarProdutoDto produto)
        {
            if (ModelState.IsValid)
                return Ok(produto);
            else
                return BadRequest(produto);
        }
    }
}


