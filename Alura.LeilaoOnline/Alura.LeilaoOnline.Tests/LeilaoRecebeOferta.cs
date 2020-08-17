using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Exceptions.Leilao;
using System;
using System.Linq;
using Xunit;
namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(new float[] { 800, 900, 100, 990 })]
        [InlineData(new float[] { 800, 900, 1000, 1990 })]
        [InlineData(new float[] { 800 })]
        public void NãoPermiteNovosLancesDadoLeilaoFinalizado(float[] ofertas)
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var sonic = new Interessada("Sonic", leilao);

            leilao.IniciaPregao();
            foreach (float o in ofertas)
            {
                leilao.RecebeLance(sonic, o);
            };

            leilao.TerminaPregao();


            Exception exception = null;

            try
            {
                leilao.RecebeLance(sonic, 99999);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.True(exception != null && exception.GetType() == typeof(LeilaoException));
        }
    }
}