using Pessoa.Domain.Entities.Base;
using Pessoa.Domain.Entities.Enums;

namespace Pessoa.Domain.Entities;

public abstract class Pessoa : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public Guid EnderecoId { get; private set; }
    public virtual Endereco Endereco { get; private set; }
    public PessoaTipo Tipo { get; private set; }

    public void InformeEnderecoId(Guid id)
    {
        EnderecoId = id;
    }
}