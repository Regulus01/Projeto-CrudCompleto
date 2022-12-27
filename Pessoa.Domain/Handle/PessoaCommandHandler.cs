using MediatR;
using Pessoa.Domain.Commands;

namespace Pessoa.Domain.Handle;

public class PessoaCommandHandler : IRequestHandler<CriarPessoaFisicaCommand>, 
                                    IRequestHandler<CriarPessoaJuridicaCommand>
{
    public Task<Unit> Handle(CriarPessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(CriarPessoaJuridicaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}