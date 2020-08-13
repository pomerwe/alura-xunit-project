using Alura.LeilaoOnline.Core;
using System;
using System.Drawing;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteDoGanhadorLeilao();
            TesteDoGanhadorLeilaoApenasUmLance();
        }

        private static void TesteDoGanhadorLeilao()
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

            AssetEquals(valorEsperado, valorObtido);
        }


        private static void TesteDoGanhadorLeilaoApenasUmLance()
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

            AssetEquals(valorEsperado, valorObtido);
        }
        
        private static void AssetEquals(object expected, object value)
        {
            var cor = Console.ForegroundColor;
            if (expected.Equals(value))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Teste Falhou");
            }
            Console.ForegroundColor = cor;
        }
    }
}
