using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{
    public class LeilaoComValorAlvo : Leilao
    {

        public LeilaoComValorAlvo(string peca, double valorAlvo) : base(peca)
        {
            ValorAlvo = valorAlvo;
            LeilaoModalidade = LeilaoModalidade.ComValorAlvo;
        }

        public override void DefinirGanhador()
        {
            Ganhador = new Lance(null, 0);

            double moduloDoValorAlvoMenosOValorDoLance = 0;
            List<Lance> lancesList = Lances.ToList();
            for (int i = 0; i < lancesList.Count; i++)
            {
                var l = lancesList[i];
                if (i == 0)
                {
                    Ganhador = l;
                    moduloDoValorAlvoMenosOValorDoLance = Math.Abs(ValorAlvo - l.Valor);
                }
                else
                {
                    double novoModuloAlvoMenosValor = Math.Abs(ValorAlvo - l.Valor);
                    if (moduloDoValorAlvoMenosOValorDoLance > novoModuloAlvoMenosValor)
                    {
                        Ganhador = l;
                        moduloDoValorAlvoMenosOValorDoLance = novoModuloAlvoMenosValor;
                    }
                }
            }
        }
    }
}
