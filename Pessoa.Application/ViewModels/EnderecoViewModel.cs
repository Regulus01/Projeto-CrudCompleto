using Pessoa.Domain.Entities.Enums;

namespace Pessoa.Application.ViewModels;

public class EnderecoViewModel
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Uf { get; set; }
}