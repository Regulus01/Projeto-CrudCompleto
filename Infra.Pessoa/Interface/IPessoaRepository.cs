using Pessoa.Domain.Entities;

namespace Infra.Pessoa.Interface;

public interface IPessoaRepository
{
    PessoaFisica ObterPessoaFisicaPorId(Guid id);
    PessoaJuridica ObterPessoaJuridicaPorId(Guid id);
}