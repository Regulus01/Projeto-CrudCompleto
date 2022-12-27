namespace Pessoa.Domain.Commands;

public class CriarPessoaFisicaCommand : CriarPessoaBaseCommand
{
    public string Cpf { get; set; }
    public string Idade { get; set; }
}