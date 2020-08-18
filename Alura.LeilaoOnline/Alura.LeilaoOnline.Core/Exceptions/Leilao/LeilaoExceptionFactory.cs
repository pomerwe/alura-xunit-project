using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Exceptions.Leilao
{
    public interface LeilaoExceptionFactory
    {
        LeilaoException CriarLeilaoExceptionParaRecebeLance(EstadoLeilao estadoLeilao);
        LeilaoException CriarLeilaoExceptionParaTerminaPregao(EstadoLeilao estadoLeilao);
        LeilaoException CriarLeilaoException(string mensagem);
    }
}
