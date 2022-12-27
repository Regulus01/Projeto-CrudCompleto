using MediatR;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Entities.Enums;

namespace Pessoa.Domain.Commands;

public class CriarPessoaBaseCommand : IRequest<Unit>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Endereco Endereco { get; set; }
    public PessoaTipo Tipo { get; private set; }
}