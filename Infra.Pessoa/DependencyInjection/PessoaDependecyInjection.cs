using Infra.Pessoa.Repository;
using Microsoft.Extensions.DependencyInjection;
using Pessoa.Application.AppService;
using Pessoa.Application.Interface;
using Pessoa.Domain.Interface;

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
        serviceProvider.AddScoped<IPessoaAppService, PessoaAppService>();
    }
}