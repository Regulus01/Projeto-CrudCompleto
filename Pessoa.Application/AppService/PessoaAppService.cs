using AutoMapper;
using MediatR;
using Pessoa.Application.Interface;
using Pessoa.Application.ViewModels;
using Pessoa.Domain.Commands;
using Pessoa.Domain.Interface;

namespace Pessoa.Application.AppService;

public class PessoaAppService : IPessoaAppService
{
    private readonly IMediator _mediator;
    private readonly IPessoaRepository _repository;
    private readonly IMapper _mapper;

    public PessoaAppService(IMediator mediator, IPessoaRepository repository, IMapper mapper)
    {
        _mediator = mediator;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string?> CriarPessoaFisica(PessoaFisicaViewModel? pessoa)
    {
        if (pessoa == null)
            return null;
        
        if (_repository.ObterEmailCadastrado(pessoa.Email))
            return null;

        var command = _mapper.Map<PessoaFisicaViewModel, CriarPessoaFisicaCommand>(pessoa);
        
        var result = await _mediator.Send(command);

        return result;
    }
}