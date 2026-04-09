using Microsoft.EntityFrameworkCore;
using Seguro.Domain.Entities;

namespace Seguro.Infrastructure.Data;

public class SeguroDbContext : DbContext
{
    public SeguroDbContext(DbContextOptions<SeguroDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apolice>().OwnsOne(s => s.Segurado);
        modelBuilder.Entity<Apolice>().OwnsOne(s => s.Veiculo);
    }
    public DbSet<Apolice> Seguros { get; set; }
}