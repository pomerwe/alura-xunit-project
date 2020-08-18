using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.LeilaoModel;
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
            var leilao = new LeilaoMaiorValor("Excalibur");

            var sonic = new Interessada("Sonic", leilao);
            var arthur = new Interessada("Arthur", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var o = ofertas[i];
                if(i % 2 == 0)
                {
                    leilao.RecebeLance(sonic, o);
                }
                else
                {
                    leilao.RecebeLance(arthur, o);
                }
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
            var leilao = new LeilaoMaiorValor("Excalibur");
            leilao.IniciaPregao();

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


        [Theory]
        [InlineData(800, 500, new float[] { 800, 900, 100, 990 })]
        [InlineData(1250, 1500, new float[] { 800, 900, 1250, 1990 })]
        [InlineData(800, 650, new float[] { 800 })]
        public void RetornaValorMaisProximoDadoLeilaoComValorAlvo(float valorEsperado, double valorAlvo, float[] ofertas)
        {
            //Arrange - cenário do teste
            var leilao = new LeilaoComValorAlvo("Excalibur", valorAlvo);

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


            //Act - método em teste 
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
