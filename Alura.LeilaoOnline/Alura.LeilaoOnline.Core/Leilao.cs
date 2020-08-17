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
            if(EstadoLeilao == EstadoLeilao.EmAndamento)
            {
                _lances.Add(new Lance(cliente, valor));
            }
            else
            {
                throw new LeilaoException("Pregão não foi iniciado, impossível receber lances!");
            }
            
        }

        public void IniciaPregao()
        {
            EstadoLeilao = EstadoLeilao.EmAndamento;
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(l => l.Valor)
                        .LastOrDefault();

            EstadoLeilao = EstadoLeilao.Finalizado;
        }
    }
}