using Comex.Models;

using Xunit;

namespace Comex.Testes
{
    public class VestuarioTestes
    {
        [Fact]
        public void Deve_extrair_o_tamanho_do_vestuario()
        {
            var vestuario = new Vestuario(nome: "Camisa",
            precoUnitario: 10.00m,
            quantidadeEmEstoque: 12,
            categoria: "Vestuario",
            atributos: "tamanho: G");

            Assert.Equal("G", vestuario.Tamanho);
        }

        [Fact]
        public void Deve_extrair_a_cor_do_vestuario()
        {
            var vestuario = new Vestuario("Camisa", 10.00m, 10, "Vestuario", "cor: Preto");

            Assert.Equal("Preto", vestuario.Cor);
        }

        [Fact]
        public void Deve_extrair_a_cor_e_o_tamanho_do_vestuario()
        {
            var vestuario = new Vestuario("Camisa", 10.00m, 10, "Vestuario", "cor: Rosa; Tamanho: M");

            Assert.Equal("Rosa", vestuario.Cor);
            Assert.Equal("M", vestuario.Tamanho);
        }
    }
}
