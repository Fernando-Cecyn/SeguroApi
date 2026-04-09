using Seguro.Domain.Services;
using Xunit;

public class SeguroCalculatorTests
{
    [Fact]
    public void Deve_Calcular_CorretamentePositivos()
    {
        var calc = new SeguroCalculator();

        var resultado = calc.Calcular(10000);

        Assert.Equal(270.37m, resultado);
    }
    [Fact]
    public void Deve_Calcular_CorretamenteDecimais()
    {
        var calc = new SeguroCalculator();

        var resultado = calc.Calcular(10000.01m);

        Assert.Equal(270.37m, resultado);
    }

    [Fact]
    public void Deve_Calcular_CorretamenteZerado()
    {
        var calc = new SeguroCalculator();

        var resultado = calc.Calcular(0);

        Assert.Equal(0, resultado);
    }


    [Fact]
    public void Deve_Calcular_CorretamenteNegativo()
    {
        var calc = new SeguroCalculator();

        var resultado = calc.Calcular(-10000);

        Assert.Equal(270.37m, resultado);
    }

}