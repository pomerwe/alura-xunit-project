using Alura.LeilaoOnline.Core.LeilaoModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{
    public interface IModalidadeAvaliador
    {
        Lance ObterGanhadorDoLeilao(Leilao leilao);
    }
}
