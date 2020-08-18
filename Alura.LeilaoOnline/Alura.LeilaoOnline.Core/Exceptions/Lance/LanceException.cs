using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Exceptions.Lance
{
    public class LanceException : Exception
    {
        public LanceException(string message) : base(message)
        {

        }
    }
}
