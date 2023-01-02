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
    ///     EndPoint authorize para criar uma pessoa fisica
    /// </summary>
    ///  <remarks>
    ///       End point usado para criar produto utilizando uma pessoa fisica a partir de uma viewModel
    ///  </remarks>
    /// <returns>
    ///     Sem retorno
    /// </returns>
    /// <response code="200"> Produto inserido no banco </response>
    /// <response code="401"> Não autorizado </response>
    [HttpPost]
    public async Task<ActionResult<PessoaFisicaViewModel>> CriarPessoaViewModel([FromBody] PessoaFisicaViewModel viewModel)
    {
        var result = _appService.CriarPessoaFisica(viewModel);

        return Ok(result);
    }
}