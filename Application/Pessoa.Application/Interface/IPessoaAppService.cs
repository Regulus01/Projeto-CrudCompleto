using Pessoa.Application.ViewModels;

namespace Pessoa.Application.Interface;

public interface IPessoaAppService
{
    Task<string?> CriarPessoaFisica(PessoaFisicaViewModel? pessoa);
    Task<string?> CriarPessoaJuridica(PessoaJuridicaViewModel? pessoa);
    Task<List<PessoaViewModelGrid>> ObterPessoasCadastradas();

}