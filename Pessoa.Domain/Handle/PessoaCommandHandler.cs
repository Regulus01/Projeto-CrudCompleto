using AutoMapper;
using MediatR;
using Pessoa.Domain.Commands;
using Pessoa.Domain.Commands.Notification;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Interface;

namespace Pessoa.Domain.Handle;

public class PessoaCommandHandler : IRequestHandler<CriarPessoaFisicaCommand, string>, 
                                    IRequestHandler<CriarPessoaJuridicaCommand, string>
{

    private readonly IPessoaRepository _repository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PessoaCommandHandler(IPessoaRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }


    public async Task<string> Handle(CriarPessoaFisicaCommand command, CancellationToken cancellationToken)
    {
        var pessoa = _mapper.Map<CriarPessoaFisicaCommand, PessoaFisica>(command);

        try
        {
            _repository.AdicionarPessoaFisica(pessoa);
            await _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email });
            return await Task.FromResult("Pessoa fisica Criada");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email });
            await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            return await Task.FromResult("Ocorreu um erro no momento da alteração");
        }
    }

    public async Task<string> Handle(CriarPessoaJuridicaCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
            return null;
        

        if (_repository.ObterEmailCadastrado(command.Email))
            return null;

        var pessoa = _mapper.Map<CriarPessoaJuridicaCommand, PessoaJuridica>(command);

        try
        {
            _repository.AdicionarPessoaJuridica(pessoa);
            await _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email });

            return await Task.FromResult("Pessoa fisica Criada");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email });
            await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
            return await Task.FromResult("Ocorreu um erro no momento da alteração");
        }
    }
}