using Infra.Pessoa.Interface;
using Infra.Pessoa.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Pessoa.DependencyInjection;

public class PessoaDependecyInjection
{
    public static void Register(IServiceCollection serviceProvider)
    {
        RepositoryDependence(serviceProvider);
    }

    private static void RepositoryDependence(IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IPessoaRepository, PessoaRepository>();
    }
}