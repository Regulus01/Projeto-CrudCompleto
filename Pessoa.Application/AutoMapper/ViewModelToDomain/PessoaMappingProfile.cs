using AutoMapper;
using Pessoa.Application.ViewModels;
using Pessoa.Domain.Entities;
using PessoaDomain = Pessoa.Domain.Entities.Pessoa;

namespace Pessoa.Application.AutoMapper.ViewModelToDomain;

public class PessoaMappingProfile : Profile
{
    public PessoaMappingProfile()
    {
        CreateMap<PessoaViewModel, PessoaDomain>();
        CreateMap<PessoaFisicaViewModel, PessoaFisica>();
        CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
    }
    
}