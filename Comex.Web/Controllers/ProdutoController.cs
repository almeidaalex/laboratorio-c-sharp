using Microsoft.AspNetCore.Mvc;
using Comex.Web.Data.Dto;
using Comex.Models;
using Comex.Models.Extensoes;

namespace Comex.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> _produtos = new List<Produto>();

    // [HttpGet]
    // public IActionResult RetornaMomento()
    // {
    //     return Ok(DateTime.Now);
    // }

    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] CriarProdutoDto produto)
    {
        _produtos.Add(new Produto(produto.Nome, produto.PrecoUnitario, produto.QuantidadeEmEstoque, produto.Categoria));
        var created = _produtos.Last();
        return CreatedAtAction(nameof(ObterProdutoPorId), new { Id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public IActionResult ObterProdutoPorId(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto.IsNull())
            return NotFound();
        return Ok(produto);
    }

    [HttpGet]
    public IActionResult ObterProdutos(string? pesquisa, int? preco)
    {
        if (string.IsNullOrWhiteSpace(pesquisa))
            return Ok(_produtos);
        var produtos = _produtos.Where(p => p.Categoria == pesquisa);
        if (produtos.IsNull())
            return NotFound();
        return Ok(produtos);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarProduto([FromBody] AtualizarProdutoDto atualizarProduto, int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto.IsNull())
            return NotFound();

        produto.Nome = atualizarProduto.Nome;
        produto.PrecoUnitario = atualizarProduto.PrecoUnitario;
        produto.QuantidadeEmEstoque = atualizarProduto.QuantidadeEmEstoque;
        produto.Categoria = atualizarProduto.Categoria;

        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverProduto(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto.IsNull())
            return NotFound();

        _produtos.Remove(produto);

        return NoContent();
    }
}
