using MediatR;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Entities.Enums;

namespace Pessoa.Domain.Commands.Base;

public class CriarPessoaBaseCommand : IRequest<string>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public Endereco Endereco { get; private set; }
    public PessoaTipo Tipo { get; private set; }
}