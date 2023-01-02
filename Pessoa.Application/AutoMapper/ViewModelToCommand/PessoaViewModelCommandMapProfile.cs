using AutoMapper;
using Pessoa.Application.ViewModels;
using Pessoa.Domain.Commands;

namespace Pessoa.Application.AutoMapper.ViewModelToCommand;

public class PessoaViewModelCommandMapProfile : Profile
{
    public PessoaViewModelCommandMapProfile()
    {
        CreateMap<PessoaFisicaViewModel, CriarPessoaFisicaCommand>().ReverseMap();
    }
}