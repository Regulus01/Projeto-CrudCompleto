using AutoMapper;
using Infra.CrossCruting.Validators;
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

        if (!DocumentValidator.IsCpf(pessoa.Cpf))
            return null;

        if (pessoa.Endereco.Uf.Length != 2)
            return null;
        
        var command = _mapper.Map<PessoaFisicaViewModel, CriarPessoaFisicaCommand>(pessoa);
        
        var result = await _mediator.Send(command);

        return result;
    }
    public async Task<string?> CriarPessoaJuridica(PessoaJuridicaViewModel? pessoa)
    {
        if (pessoa == null)
            return null;
        
        if (_repository.ObterEmailCadastrado(pessoa.Email))
            return null;

        if (!DocumentValidator.IsCnpj(pessoa.Cnpj))
            return null;

        if (pessoa.Endereco.Uf.Length != 2)
            return null;
        
        var command = _mapper.Map<PessoaJuridicaViewModel, CriarPessoaJuridicaCommand>(pessoa);
        
        var result = await _mediator.Send(command);

        return result;
    }
}