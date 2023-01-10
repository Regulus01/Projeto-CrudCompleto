using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Usuario.Common;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsuarioContext>
{
    public UsuarioContext CreateDbContext(string[] args)
    {
        var fileName = Directory.GetCurrentDirectory() + $"/Config/appsettings.json";

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");

        var optionsBuilder = new DbContextOptionsBuilder<UsuarioContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new UsuarioContext(optionsBuilder.Options);
    }
}