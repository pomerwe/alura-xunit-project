using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Exceptions.Leilao;
using Alura.LeilaoOnline.Core.LeilaoModel;
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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Excalibur", modalidade);
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

            Assert.Throws<LeilaoException>(() => leilao.RecebeLance(sonic, 999999));
        }

        [Fact]
        public void NaoAceitaLanceDadoUltimoLanceSerDoMesmoCliente()
        {
            //Arrange - cenário do teste
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Excalibur", modalidade);
            var sonic = new Interessada("Sonic", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(sonic, 1212);

            Assert.Throws<LeilaoException>(() => leilao.RecebeLance(sonic, 1212));
        }
    }
}