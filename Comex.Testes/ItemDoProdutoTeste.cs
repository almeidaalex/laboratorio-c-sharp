using Comex.Models;

using Xunit;

namespace Comex.Testes
{
    public class ItemDoPedidoTestes
    {
        [Fact]
        public void Deve_calcular_quantidade_do_Item_do_Pedido()
        {
            var produto = new Produto("Cabo RJ", 10.0m, 30, "Informática");
            var item = new ItemDoPedido(produto, 3);

            Assert.Equal(30.0m, item.Total, 2);
        }

        [Fact]
        public void Deve_calcular_o_total_novamente_apos_mudar_a_quantidade()
        {
            var produto = new Produto(nome: "Camisas", precoUnitario: 10.0m,
                                    quantidadeEmEstoque: 30, categoria: "Informática");
            var item = new ItemDoPedido(produto, 3);
            item.Quantidade = 4;

            Assert.Equal(40.0m, item.Total, 2);
        }
    }
}
