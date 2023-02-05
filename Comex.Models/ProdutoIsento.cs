
namespace Comex.Models;

public class ProdutoIsento : Produto<int>
{
    public ProdutoIsento(string nome, double precoUnitario, int quantidadeEmEstoque, string categoria)
     : base(nome, precoUnitario, quantidadeEmEstoque, categoria)
    {

    }

    public override decimal CalculaImposto()
    {
        return 0;
    }
}
