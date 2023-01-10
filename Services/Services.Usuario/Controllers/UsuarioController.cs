using Authetication.Application.AppService;
using Domain.Authentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.Usuario.Controllers;

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _repository;
    
    public UsuarioController(IUsuarioRepository appService)
    {
        _repository = appService;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody]Domain.Authentication.Domain.Usuario model)
    {
        // Recupera o usuário
        var user = _repository.Get(model.Username, model.Password);

        // Verifica se o usuário existe
        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Password = "";
    
        // Retorna os dados
        return new
        {
            user = user,
            token = token
        };
    }
    
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
}