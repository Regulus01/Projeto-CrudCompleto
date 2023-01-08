using MediatR;
using Pessoa.Domain.Commands.Base;

namespace Pessoa.Domain.Commands;

public class CriarPessoaFisicaCommand : CriarPessoaBaseCommand
{
    public string Cpf { get; private set; }
    public string Idade { get; private set; }
}