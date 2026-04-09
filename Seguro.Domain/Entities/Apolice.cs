namespace Seguro.Domain.Entities;

public class Apolice
{
    public int Id { get; set; }

    public Veiculo Veiculo { get; set; }
    public Segurado Segurado { get; set; }

    public decimal ValorSeguro { get; set; }
}