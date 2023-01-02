using AutoMapper;
using Pessoa.Domain.Commands;
using Pessoa.Domain.Entities;

namespace Pessoa.Application.AutoMapper.CommandToDomain;

public class PessoaCommandMapProfile: Profile
{
    public PessoaCommandMapProfile()
    {
        CreateMap<CriarPessoaFisicaCommand, PessoaFisica>();
        CreateMap<CriarPessoaJuridicaCommand, PessoaJuridica>();
    }
}