using Alura.LeilaoOnline.Core.Exceptions.Leilao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core.LeilaoModel
{ 
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; set; }
        public Lance Ganhador { get; set; }
        public EstadoLeilao EstadoLeilao { get; set; }
        public IModalidadeAvaliador _avaliador { get; set; }
        public double ValorAlvo { get; set; }

        public Leilao(string peca, IModalidadeAvaliador _avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            EstadoLeilao = EstadoLeilao.Iniciado;
            this._avaliador = _avaliador;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            Lance lance = new Lance(cliente, valor);
            ChecarSeLancePodeSerAdicionado(lance);
            _lances.Add(lance);
        }

        public void ChecarSeLancePodeSerAdicionado(Lance lance)
        {
            bool leilaoNaoPermiteAceitarLances = EstadoLeilao != EstadoLeilao.EmAndamento;

            bool eOClienteDoUltimoLance = Lances
                                            .DefaultIfEmpty(new Lance(null,0))
                                            .LastOrDefault()
                                            .Cliente == lance.Cliente;

            if(leilaoNaoPermiteAceitarLances)
            {
                throw GetLeilaoExceptionFactory().CriarLeilaoExceptionParaRecebeLance(EstadoLeilao);
            }

            if(eOClienteDoUltimoLance)
            {
                throw GetLeilaoExceptionFactory().CriarLeilaoException("Cliente deu o último lance! Ação negada!");
            }
        }

        public LeilaoExceptionFactoryImpl GetLeilaoExceptionFactory()
        {
            return new LeilaoExceptionFactoryImpl();
        }

        public void IniciaPregao()
        {
            EstadoLeilao = EstadoLeilao.EmAndamento;
        }

        public void TerminaPregao()
        {
            VerificaSePodeTerminarPregao();
            DefinirGanhador();
            EstadoLeilao = EstadoLeilao.Finalizado;
        }

        public void DefinirGanhador()
        {
            Ganhador = _avaliador.ObterGanhadorDoLeilao(this);
        }

        public void VerificaSePodeTerminarPregao()
        {
            if (EstadoLeilao != EstadoLeilao.EmAndamento)
            {
                throw GetLeilaoExceptionFactory().CriarLeilaoExceptionParaTerminaPregao(EstadoLeilao);
            }
        }
    }
}