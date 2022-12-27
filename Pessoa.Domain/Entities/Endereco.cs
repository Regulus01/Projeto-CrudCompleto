using Pessoa.Domain.Entities.Base;

namespace Pessoa.Domain.Entities;

public class Endereco : BaseEntity
{
    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Uf { get; private set; }
}