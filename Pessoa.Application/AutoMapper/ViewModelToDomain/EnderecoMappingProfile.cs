using AutoMapper;
using Pessoa.Application.ViewModels;
using Pessoa.Domain.Entities;

namespace Pessoa.Application.AutoMapper.ViewModelToDomain;

public class EnderecoMappingProfile : Profile
{
    public EnderecoMappingProfile()
    {
        CreateMap<EnderecoViewModel, Endereco>();
    }
}