using System.Text.RegularExpressions;

using Comex.Models.Extensoes;

namespace Comex.Models
{
    public class Vestuario : Produto
    {
        public Vestuario(string nome, decimal precoUnitario, int quantidadeEmEstoque, string categoria, string atributos)
            :base(nome, precoUnitario, quantidadeEmEstoque, categoria)
        {

            base.Atributos = atributos;
        }

        public string Tamanho => Atributos.ExtrairTamanho();

        public string Cor => Atributos.ExtrairCor();

    }
}
