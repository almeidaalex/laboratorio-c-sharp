using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Comex.Web.Data.Dto
{
    public class CriarProdutoDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Range(0.01, 100_000_000)]
        public decimal PrecoUnitario { get; set; }

        [Range(1, int.MaxValue)]
        public int QuantidadeEmEstoque { get; set; }
    }
}
