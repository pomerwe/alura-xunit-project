using System;

public class LeilaoRecebeOferta
{
    [Fact]
    public void NãoPermiteNovosLancesDadoLeilaoFinalizado()
    {
        //Arrange - cenário do teste
        var leilao = new Leilao("Excalibur");
        var arthur = new Interessada("Arthur", leilao);
        var sonic = new Interessada("Sonic", leilao);

        foreach (float o in ofertas)
        {
            leilao.RecebeLance(sonic, o);
        });


        //Act - método em teste 
        leilao.TerminaPregao();


        //Assert - Teste do resultado
        var valorObtido = leilao.Ganhador.Valor;

        Assert.Equal(valorEsperado, valorObtido);
    }
}
