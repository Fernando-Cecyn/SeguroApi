using Seguro.Domain.Entities;



namespace Seguro.Application.Interfaces;

public interface ISeguroRepository
{
    Task<Apolice> AdicionarAsync(Apolice seguro);
    Task<Apolice> ObterPorIdAsync(int id);
    Task<List<Apolice>> ObterTodosAsync();
}