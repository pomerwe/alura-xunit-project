using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{
    public class LeilaoMaiorValor : Leilao
    {
        public LeilaoMaiorValor(string peca) : base(peca)
        {
            LeilaoModalidade = LeilaoModalidade.MaiorValor;
        }
        public override void DefinirGanhador()
        {
            Ganhador = Lances
                           .DefaultIfEmpty(new Lance(null, 0))
                           .OrderBy(l => l.Valor)
                           .LastOrDefault();
        }
    }
}
