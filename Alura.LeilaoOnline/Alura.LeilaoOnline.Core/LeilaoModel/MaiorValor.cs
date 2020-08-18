using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{
    public class MaiorValor : IModalidadeAvaliador
    {
        LeilaoModalidade LeilaoModalidade = LeilaoModalidade.MaiorValor;
        public Lance ObterGanhadorDoLeilao(Leilao leilao)
        {
            return leilao.Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(l => l.Valor)
                        .LastOrDefault();
        }
    }
}
