using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos.Adapters;
using Pottencial.Application.Dtos.Reponses;
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
    ///    Autentifica usuário cadastrado na base
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns>TOKEN JWT</returns>
    /// <response code="201">Token JWT para ser utilizado nas próximas requests</response>
    /// <response code="404">Mensagem de erro</response>
    [HttpPost]
    [Route(nameof(Login))]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Login([FromBody] UsuarioLoginViewModel userLogin)
    {
        var authenticated = _usuarioAppService.Login(userLogin);

        if (authenticated) return Ok(_jwtGenerator.GerarTokenJWT());

        return NotFound(new ErrorViewModel(404, "Informe credências válidas")); 
    }


    /// <summary>
    ///     Cria um usuario na base de dados
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns>O usuário cadastrado</returns>
    /// <response code="201">Retorna o usuário criado</response>
    /// <response code="400">Email ou senha são strings nulas ou vazias</response>
    [HttpPost]
    [Route(nameof(CriarUsuario))]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriarUsuario([FromBody] UsuarioLoginViewModel userLogin)
    {
        var user = _usuarioAppService.CriarUsuario(userLogin);

        if (user is null) return BadRequest(new ErrorViewModel(400,"E-mail ou senha são obrigatórios"));

        return Created(nameof(CriarUsuario),user);
    }
}
