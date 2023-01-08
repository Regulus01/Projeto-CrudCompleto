using Infra.Pessoa.Common;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Interface;

namespace Infra.Pessoa.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly PessoaContext _context;

    public PessoaRepository(PessoaContext context)
    {
        _context = context;
    }

    public PessoaFisica ObterPessoaFisicaPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public PessoaJuridica ObterPessoaJuridicaPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PessoaFisica> ObterPessoasFisicas()
    {
        return _context.PessoaFisica.OrderBy(x => x.Nome)
                                    .ThenBy(x => x.Email);
    }
    public IEnumerable<PessoaJuridica> ObterPessoasJuridicas()
    {
        return _context.PessoaJuridica.OrderBy(x => x.Nome)
                                      .ThenBy(x => x.Email);
    }
    public bool ObterEmailCadastrado(string email)
    {
        var pessoaFisica = _context.PessoaFisica.FirstOrDefault(x => x.Email == email);
        var pessoaJuridica = _context.PessoaJuridica.FirstOrDefault(x => x.Email == email);

        return pessoaFisica != null || pessoaJuridica != null;
    }

    public void AdicionarPessoaFisica(PessoaFisica pessoa)
    {
        _context.Add(pessoa);
    }

    public void AdicionarPessoaJuridica(PessoaJuridica pessoa)
    {
        _context.Add(pessoa);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

}