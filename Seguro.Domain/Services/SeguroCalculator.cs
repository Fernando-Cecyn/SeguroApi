namespace Seguro.Domain.Services;

public class SeguroCalculator
{
    private const decimal MARGEM_SEGURANCA = 0.03m;
    private const decimal LUCRO = 0.05m;

    public decimal Calcular(decimal valorVeiculo)
    {

        if (valorVeiculo == 0) return (0); //Pegar Edge Case de valores Zerado;
        if (valorVeiculo < 0) valorVeiculo = valorVeiculo * -1; //Pegar Edge Case de valores Negativo;
        var taxaRisco = (((valorVeiculo * 5) / (2 * valorVeiculo)) / 100); ///  (Valor do Veículo * 5) /(2 x Valor do Veículo)  --> Constante 2.5?  // Divisão por 100 para deixar em taxa pct
        var premioRisco = taxaRisco * valorVeiculo; 
        var premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);
        var premioComercial = premioPuro * (1 + LUCRO);

        return Math.Round(premioComercial, 2, MidpointRounding.ToZero); // Originalmente em Math Round to even, trocado para to zero para conincidir com resposta esperada.
    }
}