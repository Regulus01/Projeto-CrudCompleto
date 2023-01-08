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
        
        var command = _mapper.Map<CriarPessoaFisicaCommand>(pessoa);
        
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
        
        var command = _mapper.Map<CriarPessoaJuridicaCommand>(pessoa);
        
        var result = await _mediator.Send(command);

        return result;
    }

    public Task<List<PessoaViewModelGrid>> ObterPessoasCadastradas()
    {
        var pessoasFisicas = _repository.ObterPessoasFisicas();
        var pessoasJuridicas = _repository.ObterPessoasJuridicas();

        var pessoasGrid = new List<PessoaViewModelGrid>();
        
        pessoasGrid.AddRange(_mapper.Map<IEnumerable<PessoaViewModelGrid>>(pessoasFisicas));
        pessoasGrid.AddRange(_mapper.Map<IEnumerable<PessoaViewModelGrid>>(pessoasJuridicas));

        return Task.FromResult(pessoasGrid);

    }
}