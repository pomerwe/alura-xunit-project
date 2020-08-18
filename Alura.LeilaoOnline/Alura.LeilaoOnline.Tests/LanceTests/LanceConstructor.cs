using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Exceptions.Lance;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests.LanceTests
{
    public class LanceConstructor
    {
        [Fact]
        public void RetornaExcecaoDadoValorDeLanceNegativo()
        {
            Assert.Throws<LanceException>(() => new Lance(null, -100));
        }
    }
}
