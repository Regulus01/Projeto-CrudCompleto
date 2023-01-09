namespace Pessoa.Application.ViewModels;

public class PessoaFisicaViewModel : PessoaViewModel
{
    public string Cpf { get; set; }
    public string Idade { get; set; }
    public EnderecoViewModel Endereco { get; set; }
}