using Domain.Authentication.Interface;
using Infra.Usuario.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Usuario.DependencyInjection;

public static class UsuarioDependencyInjection
{
    public static void Register(IServiceCollection serviceProvider)
    {
        RepositoryDependence(serviceProvider);
    }

    private static void RepositoryDependence(IServiceCollection serviceProvider)
    {
        //Inversao de dependencia
        serviceProvider.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}