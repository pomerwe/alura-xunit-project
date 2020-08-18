using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Exceptions.Leilao;
using System;
using System.Collections.Generic;
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
            var leilao = new Leilao("Excalibur");
            //Arrange - cenário do teste
            var sonic = new Interessada("Sonic", leilao);
            var arthur = new Interessada("Arthur", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var o = ofertas[i];
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(sonic, o);
                }
                else
                {
                    leilao.RecebeLance(arthur, o);
                }
            };

            leilao.TerminaPregao();


            LeilaoException leilaoException = null;

            try
            {
                leilao.RecebeLance(sonic, 99999);
            }
            catch (LeilaoException ex)
            {
                leilaoException = ex;
            }

            Assert.True(leilaoException != null && leilaoException.GetType() == typeof(LeilaoException));
        }

        [Fact]
        public void NaoAceitaLanceDadoUltimoLanceSerDoMesmoCliente()
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var sonic = new Interessada("Sonic", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(sonic, 1212);

            LeilaoException leilaoException = null;

            try
            {
                leilao.RecebeLance(sonic, 1212);
            }
            catch (LeilaoException ex)
            {
                leilaoException = ex;
            }


            Assert.True(leilaoException != null && leilaoException.GetType() == typeof(LeilaoException));
        }
    }
}