using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{
    public class ComValorAlvo : IModalidadeAvaliador
    {
        LeilaoModalidade LeilaoModalidade = LeilaoModalidade.ComValorAlvo;
        double ValorAlvo { get; set; }

        public ComValorAlvo(double valorAlvo)
        {
            ValorAlvo = valorAlvo;
        }

        public Lance ObterGanhadorDoLeilao(Leilao leilao)
        {
            Lance lanceGanhador = new Lance(null, 0);

            double moduloDoValorAlvoMenosOValorDoLance = 0;
            List<Lance> lancesList = leilao.Lances.ToList();
            for (int i = 0; i < lancesList.Count; i++)
            {
                var l = lancesList[i];
                if (i == 0)
                {
                    lanceGanhador = l;
                    moduloDoValorAlvoMenosOValorDoLance = Math.Abs(ValorAlvo - l.Valor);
                }
                else
                {
                    double novoModuloAlvoMenosValor = Math.Abs(ValorAlvo - l.Valor);
                    if (moduloDoValorAlvoMenosOValorDoLance > novoModuloAlvoMenosValor)
                    {
                        lanceGanhador = l;
                        moduloDoValorAlvoMenosOValorDoLance = novoModuloAlvoMenosValor;
                    }
                }
            }

            return lanceGanhador;
        }
    }
}
