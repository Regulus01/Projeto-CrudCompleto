using Pessoa.Domain.Entities.Enums;

namespace Pessoa.Application.ViewModels;

public class PessoaViewModelGrid
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public PessoaTipo Tipo { get; set; }
}