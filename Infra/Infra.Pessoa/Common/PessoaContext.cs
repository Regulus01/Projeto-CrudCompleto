using Infra.Pessoa.Maps;
using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Common;

public sealed class PessoaContext : DbContext
{
    public DbSet<PessoaFisica> PessoaFisica { get; set; }
    public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    
    public PessoaContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    public PessoaContext(DbContextOptions<PessoaContext> builderOptions) : base(builderOptions)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PessoaFisicaMap());
        modelBuilder.ApplyConfiguration(new PessoaJuridicaMap());
        modelBuilder.ApplyConfiguration(new EnderecoMap());
    }
}
