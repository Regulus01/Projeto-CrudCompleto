using Infra.Pessoa.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pessoa.Application.AppService;
using Pessoa.Application.AutoMapper;
using Pessoa.Application.Interface;
using Pessoa.Domain.Commands;
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
        //Auto mapper
        var mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
        serviceProvider.AddSingleton(mapper);
        serviceProvider.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        //Inversao de dependencia
        serviceProvider.AddScoped<IPessoaRepository, PessoaRepository>();
        serviceProvider.AddScoped<IPessoaAppService, PessoaAppService>();
        
        //Mediatr commands
        serviceProvider.AddMediatR(typeof(CriarPessoaFisicaCommand).Assembly);
        serviceProvider.AddMediatR(typeof(CriarPessoaJuridicaCommand).Assembly);
    }
}