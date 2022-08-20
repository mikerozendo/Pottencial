using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;
using Pottencial.Infraestructure.CrossCutting.JWT.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : AppBaseController
{
    private readonly IUsuarioAppService _usuarioAppService;
    private readonly IJwtGenerator _jwtGenerator;
    public AuthController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _usuarioAppService = (IUsuarioAppService)GetService(typeof(IUsuarioAppService));
        _jwtGenerator = (IJwtGenerator)GetService(typeof(IJwtGenerator));
    }

    /// <summary>
    /// Autentifica usuario cadastrado;
    /// Retorna status de sucesso com token jwt caso a autentificação ocorra com sucesso ou NoFound com mensagem de erro;
    /// </summary>
    [HttpPost]
    [Route(nameof(Login))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Login([FromBody] UsuarioLoginViewModel userLogin)
    {
        var authenticated = _usuarioAppService.Login(userLogin);

        if (authenticated) return Ok(_jwtGenerator.GerarTokenJWT());

        return NotFound("Informe credências válidas"); 
    }


    /// <summary>
    /// Criação de usuário para posterior login no endpoint api/Auth/Login;
    /// Retorna o usuário criado com status de sucesso ou status de erro caso alguma das propriedades do DTO sejam nulas;
    /// </summary>
    [HttpPost]
    [Route(nameof(CriarUsuario))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriarUsuario([FromBody] UsuarioLoginViewModel userLogin)
    {
        var user = _usuarioAppService.CriarUsuario(userLogin);

        if (user is null) return BadRequest("Informe um usuário");

        return Created(nameof(CriarUsuario),user);
    }
}
