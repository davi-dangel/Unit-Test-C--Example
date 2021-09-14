using Alura.LeilaoOnline.Core;
using Xunit;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentoExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            var exceptionObtida = Assert.Throws<System.ArgumentException>(
                //act
                () => new Lance(null, valorNegativo)
            );

            var msgEsperada = "Valor do lance não pode ser negativo";

            //Assert
            Assert.Equal(msgEsperada, exceptionObtida.Message);
        }
    }
}
