using AutoMapper;
using Pessoa.Application.AutoMapper.CommandToDomain;
using Pessoa.Application.AutoMapper.DomainToViewModel;
using Pessoa.Application.AutoMapper.ViewModelToCommand;
using Pessoa.Application.AutoMapper.ViewModelToDomain;

namespace Pessoa.Application.AutoMapper;

public static class AutoMapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.AddProfile<PessoaMappingProfile>();
            config.AddProfile<EnderecoMappingProfile>();
            config.AddProfile<PessoaCommandMapProfile>();
            config.AddProfile<PessoaViewModelCommandMapProfile>();
            config.AddProfile<PessoaDomainToViewModelGridProfile>();
        });

    }
}