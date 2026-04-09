using Seguro.Domain.Services;
using Xunit;

public class SeguroCalculatorTests
{
    [Fact]
    public void Deve_Calcular_Corretamente()
    {
        var calc = new SeguroCalculator();

        var resultado = calc.Calcular(10000);

        Assert.Equal(270.37m, resultado);
    }
}