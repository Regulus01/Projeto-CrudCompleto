namespace Pessoa.Domain.Entities;

public class PessoaFisica : Pessoa
{
    public string Cpf { get; private set; }
    public string Idade { get; private set; }
}