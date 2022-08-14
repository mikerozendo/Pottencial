using Microsoft.AspNetCore.Mvc;
using Pottencial.Application.Dtos;
using Pottencial.Application.Interfaces;

namespace Pottencial.Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : AppBaseController
{
    private readonly IUsuarioAppService _usuarioAppService;
    public AuthController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _usuarioAppService = (IUsuarioAppService)GetService(typeof(IUsuarioAppService));
    }

    [HttpPost]
    public IActionResult Login([FromBody]UsuarioLoginViewModel userLogin)
    {
        try
        {
            var user = _usuarioAppService.Login(userLogin);
            return Ok(user);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
