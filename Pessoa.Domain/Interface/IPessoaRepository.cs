using Pessoa.Domain.Entities;

namespace Pessoa.Domain.Interface;

public interface IPessoaRepository
{
    PessoaFisica ObterPessoaFisicaPorId(Guid id);
    PessoaJuridica ObterPessoaJuridicaPorId(Guid id);
    bool ObterEmailCadastrado(string email);
    void AdicionarPessoaFisica(PessoaFisica pessoa);
    void AdicionarPessoaJuridica(PessoaJuridica pessoa);
}