using Infra.Pessoa.Interface;
using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Repository;

public class PessoaRepository : IPessoaRepository
{
    public PessoaFisica ObterPessoaFisicaPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public PessoaJuridica ObterPessoaJuridicaPorId(Guid id)
    {
        throw new NotImplementedException();
    }
}