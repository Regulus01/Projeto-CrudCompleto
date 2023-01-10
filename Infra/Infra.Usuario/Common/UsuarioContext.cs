using Infra.Usuario.Maps;
using Microsoft.EntityFrameworkCore;
using UsuarioDomain = Domain.Authentication.Domain.Usuario;

namespace Infra.Usuario.Common;

public sealed class UsuarioContext : DbContext
{
    public DbSet<UsuarioDomain> Usuario { get; set; } 
    
    public UsuarioContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    public UsuarioContext(DbContextOptions<UsuarioContext> builderOptions) : base(builderOptions)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}
