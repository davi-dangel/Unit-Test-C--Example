using Alura.LeilaoOnline.Core;
using Xunit;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoCLienteREalizouUltimo()
        {
            //Arranje - os cenários de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert - valor esperado
            var qtdeEsperada = 1;
            var qtdeObtido = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtido);
        }


        [Theory]
        [InlineData(4, new double[] {100, 1200, 1400, 1300})]
        [InlineData(2, new double[] {800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //Arranje - os cenários de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if((i % 2) == 0) leilao.RecebeLance(fulano, ofertas[i]);
                else leilao.RecebeLance(maria, ofertas[i]);
            }

            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert - valor esperado
            var qtdeObtido = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtido);
        }
    }
}
