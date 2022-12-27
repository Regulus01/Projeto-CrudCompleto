namespace Pessoa.Domain.Commands;

public class CriarPessoaJuridicaCommand : CriarPessoaBaseCommand
{
    public string Cnpj { get; set; }
}