using Comex.Models.Extensoes;

using Xunit;

namespace Comex.Models.Test
{
    public class IsNullTest
    {
        [Fact]
        public void Deve_calcular_quantidade_do_Item_do_Pedido()
        {
            object nulo = null;

            Assert.Equal(true, nulo.IsNull());
        }
    }
}
