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

    [HttpPost]
    [Route(nameof(Login))]
    public IActionResult Login([FromBody] UsuarioLoginViewModel userLogin)
    {
        var authenticated = _usuarioAppService.Login(userLogin);

        if (authenticated) return Ok(_jwtGenerator.GerarTokenJWT());

        return NotFound("Informe credências válidas");
    }


    [HttpPost]
    [Route(nameof(CriarUsuario))]
    public IActionResult CriarUsuario([FromBody] UsuarioLoginViewModel userLogin)
    {
        var user = _usuarioAppService.CriarUsuario(userLogin);

        if (user is null) return BadRequest("Informe um usuário");

        return Created(nameof(CriarUsuario),user);
    }
}
