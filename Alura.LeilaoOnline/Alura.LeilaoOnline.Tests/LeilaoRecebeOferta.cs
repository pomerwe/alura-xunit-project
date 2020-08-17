using Alura.LeilaoOnline.Core;
using System;
using System.Linq;
using Xunit;
namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(990, new float[] { 800, 900, 100, 990 })]
        [InlineData(1990, new float[] { 800, 900, 1000, 1990 })]
        [InlineData(800, new float[] { 800 })]
        public void NãoPermiteNovosLancesDadoLeilaoFinalizado(float qtDeLancesEsperado, float[] ofertas)
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var sonic = new Interessada("Sonic", leilao);

            foreach (float o in ofertas)
            {
                leilao.RecebeLance(sonic, o);
            };

            leilao.TerminaPregao();

            leilao.RecebeLance(sonic, 99999);

            //Assert - Teste do resultado
            var qtDeLancesObtido = leilao.Lances.Count();

            Assert.Equal(qtDeLancesEsperado, qtDeLancesObtido);
        }
    }
}