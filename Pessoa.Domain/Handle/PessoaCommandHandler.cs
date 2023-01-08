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


    public Task<string> Handle(CriarPessoaFisicaCommand command, CancellationToken cancellationToken)
    {
        var pessoa = _mapper.Map<CriarPessoaFisicaCommand, PessoaFisica>(command);

        try
        {
            _repository.AdicionarPessoaFisica(pessoa);
            _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email }, cancellationToken);
            
            _repository.Commit();
            return Task.FromResult("Pessoa fisica Criada.");
        }
        catch (Exception ex)
        {
            _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email }, cancellationToken);
            _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }, cancellationToken);
            return Task.FromResult("Ocorreu um erro no momento da alteração: ");
        }
    }

    public Task<string> Handle(CriarPessoaJuridicaCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
            return null;
        

        if (_repository.ObterEmailCadastrado(command.Email))
            return null;

        var pessoa = _mapper.Map<CriarPessoaJuridicaCommand, PessoaJuridica>(command);

        try
        {
            _repository.AdicionarPessoaJuridica(pessoa);
            _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email }, cancellationToken);

            return Task.FromResult("Pessoa fisica Criada");
        }
        catch (Exception ex)
        {
            _mediator.Publish(new PessoaCriadaNotification { Nome = pessoa.Nome, Email = pessoa.Email }, cancellationToken);
            _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }, cancellationToken);
            return Task.FromResult("Ocorreu um erro no momento da alteração");
        }
    }
}