using Microsoft.AspNetCore.Mvc;
using Pessoa.Application.Interface;
using Pessoa.Application.ViewModels;

namespace Pessoa.API.Controllers;

[Route("api/Pessoa")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaAppService _appService;
    public PessoaController(IPessoaAppService appService)
    {
        _appService = appService;
    }
    
    /// <summary>
    ///     EndPoint para criar uma pessoa fisica
    /// </summary>
    ///  <remarks>
    ///       End point usado para criar produto utilizando uma pessoa fisica a partir de uma viewModel
    ///  </remarks>
    /// <returns>
    ///     Sem retorno
    /// </returns>
    /// <response code="200"> Produto inserido no banco </response>
    /// <response code="401"> Não autorizado </response>
    [HttpPost("/Fisica")]
    public async Task<ActionResult<PessoaFisicaViewModel>> CriarPessoaFisica([FromBody] PessoaFisicaViewModel viewModel)
    {
        var request = _appService.CriarPessoaFisica(viewModel);

        if (request.Result == null)
        {
            return BadRequest(request);
        }
        
        return Ok(request);
    }
    
    /// <summary>
    ///     EndPoint para criar uma pessoa Juridica
    /// </summary>
    ///  <remarks>
    ///       End point usado para criar produto utilizando uma pessoa fisica a partir de uma viewModel
    ///  </remarks>
    /// <returns>
    ///     Sem retorno
    /// </returns>
    /// <response code="200"> Produto inserido no banco </response>
    /// <response code="401"> Não autorizado </response>
    [HttpPost("/Juridica")]
    public async Task<ActionResult<PessoaFisicaViewModel>> CriarPessoaJuridica([FromBody] PessoaJuridicaViewModel viewModel)
    {
        var request = _appService.CriarPessoaJuridica(viewModel);
        
        if (request.Result == null)
        {
            return BadRequest(request);
        }
        
        return Ok(request);
    }

    /// <summary>
    ///     EndPoint para obter pessoas cadastradas
    /// </summary>
    ///  <remarks>
    ///       EndPoint para obter pessoas cadastradas no sistema
    ///  </remarks>
    /// <returns>
    ///     Pessoas cadastradas
    /// </returns>
    /// <response code="200"> Pessoas cadastradas </response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaViewModelGrid>>> GetAll()
    {
        var request = _appService.ObterPessoasCadastradas();
        
        return Ok(request);
    }
}