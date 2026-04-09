using Seguro.Application.Interfaces;
using Seguro.Domain.Entities;
using Seguro.Domain.Services;

namespace Seguro.Application.Services;

public class SeguroService
{
    private readonly ISeguroRepository _repository;
    private readonly SeguroCalculator _calculator;

    public SeguroService(ISeguroRepository repository)
    {
        _repository = repository;
        _calculator = new SeguroCalculator();
    }

    public async Task<Apolice> CriarSeguroAsync(Apolice seguro)
    {
        var valor = _calculator.Calcular(seguro.Veiculo.Valor);
        seguro.ValorSeguro = valor;

        return await _repository.AdicionarAsync(seguro);
    }

    public async Task<Apolice> ObterPorIdAsync(int id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task<decimal> ObterMediaAsync()
    {
        var lista = await _repository.ObterTodosAsync();
        return lista.Any() ? lista.Average(s => s.ValorSeguro) : 0;
    }
}