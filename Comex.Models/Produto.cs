using System.Numerics;

namespace Comex.Models
{

    /// <summary>
    ///
    ///
    public class Produto
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string Categoria { get; set; }
        protected string Atributos { get; set; }

        public Produto(string nome, decimal precoUnitario, int quantidadeEmEstoque, string categoria)
        {
            Id = ++_id;
            validaEntradaDeDados(nome, precoUnitario, quantidadeEmEstoque, categoria);
        }

        public string InformacoesDoProduto()
        {
            return $" Id: {Id}\n Nome: {Nome}\n Preço Unitário: {PrecoUnitario:C2}\n Quantidade em Estoque: {QuantidadeEmEstoque}\n Categoria: {Categoria}\n";
        }

        public virtual decimal ValorTotalEmEstoque()
        {
            return QuantidadeEmEstoque * PrecoUnitario;
        }

        public virtual decimal CalculaImposto()
        {
            return PrecoUnitario * 0.40m;
        }

        public void validaEntradaDeDados(string nome, decimal precoUnitario, int quantidadeEmEstoque, string categoria)
        {
            if (nome.Length < 5)
            {
                throw new ArgumentException("O nome deve ser maior que 5 caracteres", nameof(nome));
            }
            if (precoUnitario <= 0)
            {
                throw new ArgumentException("O preço unitário deve ser maior que 0", nameof(precoUnitario));
            }
            if (quantidadeEmEstoque <= 0)
            {
                throw new ArgumentException("A quantidade em estoque deve ser maior que 0", nameof(quantidadeEmEstoque));

            }

            if (String.IsNullOrEmpty(categoria))
            {
                throw new ArgumentException("A categoria deve ser informada", nameof(categoria));
            }

            Nome = nome;
            PrecoUnitario = (decimal)precoUnitario;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Categoria = categoria;
        }
    }
}
