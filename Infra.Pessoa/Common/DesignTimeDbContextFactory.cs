using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Pessoa.Common;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PessoaContext>
{
    public PessoaContext CreateDbContext(string[] args)
    {
        var fileName = Directory.GetCurrentDirectory() + $"/Config/appsettings.json";

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");

        var optionsBuilder = new DbContextOptionsBuilder<PessoaContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new PessoaContext(optionsBuilder.Options);
    }
}