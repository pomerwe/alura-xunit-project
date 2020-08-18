using Alura.LeilaoOnline.Core.Exceptions.Leilao;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao EstadoLeilao { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();

            EstadoLeilao = EstadoLeilao.Iniciado;
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
            if (EstadoLeilao != EstadoLeilao.EmAndamento)
            {
                throw GetLeilaoExceptionFactory().CriarLeilaoExceptionParaTerminaPregao(EstadoLeilao);
            }

            Ganhador = Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(l => l.Valor)
                        .LastOrDefault();

            EstadoLeilao = EstadoLeilao.Finalizado;
        }
    }
}