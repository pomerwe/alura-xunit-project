using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Exceptions.Leilao
{
    public class LeilaoExceptionFactoryImpl : LeilaoExceptionFactory
    {
        public LeilaoException CriarLeilaoExceptionParaRecebeLance(EstadoLeilao estadoLeilao)
        {
            switch(estadoLeilao)
            {
                case EstadoLeilao.Iniciado:
                    {
                        return new LeilaoException("Pregão ainda não foi iniciado! Impossível receber lances!");
                    }
                case EstadoLeilao.Finalizado:
                    {
                        return new LeilaoException("Pregão já finalizado! Impossível receber lances!");
                    }
                case EstadoLeilao.EmAndamento:
                    {
                        return new LeilaoException("Houve algum erro ao receber lance!");
                    }
                default:
                    throw new LeilaoException("Estado de leilão não existente!");
            }
        }

        public LeilaoException CriarLeilaoException(string mensagem)
        {
            return new LeilaoException(mensagem);
        }

        public LeilaoException CriarLeilaoExceptionParaTerminaPregao(EstadoLeilao estadoLeilao)
        {
            switch (estadoLeilao)
            {
                case EstadoLeilao.Iniciado:
                    {
                        return new LeilaoException("Pregão ainda não foi iniciado!");
                    }
                case EstadoLeilao.Finalizado:
                    {
                        return new LeilaoException("Pregão já finalizado!");
                    }
                default:
                    throw new LeilaoException("Estado de leilão não existente!");
            }
        }
    }
}
