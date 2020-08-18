using Alura.LeilaoOnline.Core.Exceptions.Lance;
using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            ValidarValor(valor);

            Cliente = cliente;
            Valor = valor;
        }

        public void ValidarValor(double valor)
        {
            if(valor < 0)
            {
                throw new LanceException("Lance com valor negativo não é permitido!");
            }
        }
    }
}