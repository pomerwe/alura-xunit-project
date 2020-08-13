using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void Leilao()
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var arthur = new Interessada("Arthur", leilao);
            var sonic = new Interessada("Sonic", leilao);

            leilao.RecebeLance(arthur, 100);
            leilao.RecebeLance(sonic, 150);
            leilao.RecebeLance(sonic, 180);
            leilao.RecebeLance(arthur, 100);
            leilao.RecebeLance(arthur, 100);


            //Act - método em teste 
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            var valorEsperado = "Sonic";
            var valorObtido = leilao.Ganhador.Cliente.Nome;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComValoresOrdenados()
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var arthur = new Interessada("Arthur", leilao);
            var sonic = new Interessada("Sonic", leilao);

            leilao.RecebeLance(arthur, 100);
            leilao.RecebeLance(arthur, 101);
            leilao.RecebeLance(arthur, 102);
            leilao.RecebeLance(sonic, 150);
            leilao.RecebeLance(sonic, 180);


            //Act - método em teste 
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            var valorEsperado = "Sonic";
            var valorObtido = leilao.Ganhador.Cliente.Nome;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComTresPessoas()
        {
            //Arrange - 
            //Leilão com 3 pessoas realizando lances
            var leilao = new Leilao("Excalibur");
            var arthur = new Interessada("Arthur", leilao);
            var sonic = new Interessada("Sonic", leilao);
            var goku = new Interessada("Goku", leilao);

            leilao.RecebeLance(sonic, 23);
            leilao.RecebeLance(goku, 1133);
            leilao.RecebeLance(arthur, 232);
            leilao.RecebeLance(sonic, 424);
            leilao.RecebeLance(arthur, 234);


            //Act - método em teste 
            //Quando o leilão termina
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            //O valor esperado é o maior lance
            //E o cliente ganhador é o que deu o maior lance
            var maiorValorLance = 1133;
            var valorLanceObtido = leilao.Ganhador.Valor;

            Assert.Equal(maiorValorLance, valorLanceObtido);
            Assert.Equal(goku, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeilaoSemLances()
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

        [Fact]
        public void LeilaoUmLance()
        {
            //Arrange - cenário do teste
            var leilao = new Leilao("Excalibur");
            var arthur = new Interessada("Arthur", leilao);
            var sonic = new Interessada("Sonic", leilao);

            leilao.RecebeLance(arthur, 100);


            //Act - método em teste 
            leilao.TerminaPregao();


            //Assert - Teste do resultado
            var valorEsperado = "Arthur";
            var valorObtido = leilao.Ganhador.Cliente.Nome;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
