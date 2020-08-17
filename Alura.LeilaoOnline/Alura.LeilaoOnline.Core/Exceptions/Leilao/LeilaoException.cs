using System;
using System.Runtime.Serialization;

namespace Alura.LeilaoOnline.Core.Exceptions.Leilao
{
    [Serializable]
    public class LeilaoException : Exception
    {
        string Descricao { get; set; }
        public LeilaoException(string message) : base(message)
        {
            Descricao = message;
        }

        public LeilaoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LeilaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}