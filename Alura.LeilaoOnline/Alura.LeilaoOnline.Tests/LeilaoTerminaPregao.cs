using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(990, new float[] { 800, 900, 100, 990 })]
        [InlineData(1990, new float[] { 800, 900, 1000, 1990 })]
        [InlineData(800, new float[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(float valorEsperado, float[] ofertas)
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var sonic = new Interessada("Sonic", leilao);

            foreach(float o in ofertas)
            {
                leilao.RecebeLance(sonic, o);
            };


            //Act - método em teste 
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoComNenhumLance()
        {
            //Arrange - 
            //Leilão com 3 pessoas realizando lances
            var leilao = new Leilao("Excalibur");
            //Act - método em teste 
            //Quando o leilão termina
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            //O valor esperado é o maior lance
            //E o cliente ganhador é o que deu o maior lance
            var maiorValorLance = 0;
            var valorLanceObtido = leilao.Ganhador.Valor;

            Assert.Equal(maiorValorLance, valorLanceObtido);
        }
    }
}
