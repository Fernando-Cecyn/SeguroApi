namespace Seguro.Domain.Services;

public class SeguroCalculator
{
    private const decimal MARGEM_SEGURANCA = 0.03m;
    private const decimal LUCRO = 0.05m;

    public decimal Calcular(decimal valorVeiculo)
    {
        var taxaRisco = (((valorVeiculo * 5) / (2 * valorVeiculo)) / 100); ///  (Valor do Veículo * 5) /(2 x Valor do Veículo)  --> Constante 2.5?  // Divisão por 100 para deixar em taxa pct
        var premioRisco = taxaRisco * valorVeiculo; 
        var premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);
        var premioComercial = premioPuro * (1 + LUCRO);

        return Math.Round(premioComercial, 2);
    }
}