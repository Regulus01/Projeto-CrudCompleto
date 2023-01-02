using Pessoa.Domain.Commands.Base;

namespace Pessoa.Domain.Commands;

public class CriarPessoaJuridicaCommand : CriarPessoaBaseCommand
{
    public string Cnpj { get; private set; }
}