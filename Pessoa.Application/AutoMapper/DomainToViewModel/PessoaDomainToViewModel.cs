using AutoMapper;
using Pessoa.Application.ViewModels;
using Pessoa.Domain.Entities;

namespace Pessoa.Application.AutoMapper.DomainToViewModel;

public class PessoaDomainToViewModelGridProfile : Profile
{
    public PessoaDomainToViewModelGridProfile()
    {
        CreateMap<PessoaFisica, PessoaViewModelGrid>();
        CreateMap<PessoaJuridica, PessoaViewModelGrid>();
    }
}