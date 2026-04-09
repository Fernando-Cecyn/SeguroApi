using Microsoft.EntityFrameworkCore;
using Seguro.Application.Interfaces;
using Seguro.Domain.Entities;
using Seguro.Infrastructure.Data;

namespace Seguro.Infrastructure;

public class SeguroRepository : ISeguroRepository
{
    private readonly SeguroDbContext _context;

    public SeguroRepository(SeguroDbContext context)
    {
        _context = context;
    }

    public async Task<Apolice> AdicionarAsync(Apolice seguro)
    {
        _context.Seguros.Add(seguro);
        await _context.SaveChangesAsync();
        return seguro;
    }

    public async Task<Apolice> ObterPorIdAsync(int id)
    {
        return await _context.Seguros.FindAsync(id);
    }

    public async Task<List<Apolice>> ObterTodosAsync()
    {
        return await _context.Seguros.ToListAsync();
    }
}